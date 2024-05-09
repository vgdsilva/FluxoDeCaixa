
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace FluxoDeCaixa.Data.Data;

public class AtualizacaoDB
{

    static string scriptAtual { get; set; } = "";

    private static readonly Regex COMENTARIO_1_LINHA = new Regex(@"--.*$", RegexOptions.Multiline);
    private static readonly Regex COMENTARIO_N_LINHAS = new Regex(@"(\/\*[^*]*\*\/)|(\/\/[^*]*)|(--[^.].*)", RegexOptions.Multiline);

    private static readonly Regex MULTIPLAS_COLUNAS_EM_1_LINHA = new Regex(@", """, RegexOptions.Multiline);

    private static readonly Regex NOT_NULL_SEM_DEFAULT = new Regex(@" NOT NULL(,)?\r?$", RegexOptions.Multiline);
    private static readonly Regex NOT_NULL_COM_DEFAULT_E_PONTOEVIRGULA = new Regex(@" NOT NULL DEFAULT.*;\r?$", RegexOptions.Multiline);
    private static readonly Regex NOT_NULL_COM_DEFAULT_E_VIRGULA = new Regex(@" NOT NULL DEFAULT.*,\r?$", RegexOptions.Multiline);
    private static readonly Regex NOT_NULL_COM_DEFAULT = new Regex(@" NOT NULL DEFAULT.*\r?$", RegexOptions.Multiline);

    private static readonly Regex NULL_COM_OU_SEM_VIRGULA = new Regex(@" NULL(,)?\r?$", RegexOptions.Multiline);

    private static readonly Regex CONSTRAINT = new Regex(@"^\s*CONSTRAINT.*\r?$", RegexOptions.Multiline);

    private static readonly Regex VIRGULA_E_QUEBRAS_DE_LINHA = new Regex(@",\r?\n(\r?\n)+\);", RegexOptions.Multiline);


    private static readonly Regex QUEBRAS_DE_LINHA_E_PONTOEVIRGULA = new Regex(@"\r?\n;", RegexOptions.Multiline);
    private static readonly Regex VIRGULA_SOLITARIA = new Regex(@"\r?\n,\r?\n", RegexOptions.Multiline);

    private static readonly Regex PRAGMA_FOREIGN_KEYS = new Regex(@"^PRAGMA foreign_keys =.*$", RegexOptions.Multiline);

    public static void AtualizaBancoDeDados(Database db)
    {
        var migrationsJaExecutados = ListExecutedMigrations(db);

        var migrationsPendentes = ListPendingMigrations(db, migrationsJaExecutados);

        if ( migrationsPendentes.Count > 0 )
        {
            foreach ( var migration in migrationsPendentes )
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(migration) )
                {
                    if ( stream == null )
                        return;

                    using ( StreamReader reader = new StreamReader(stream) )
                    {
                        var script = reader.ReadToEnd();
                        var _script = AjustaScript(script);

                        var _commands = Regex.Split(_script, @";\s*\r?$", RegexOptions.Multiline);

                        foreach ( var _command in _commands )
                        {
                            var command = _command.Trim();

                            if ( string.IsNullOrEmpty(command) )
                                continue;

                            db.ExecuteNonQuery(command);

                            var splitMigration = migration.Replace("V", "").Replace("Inicial", "").Split('_');
                            var productVersion = string.Concat(".", splitMigration[0], splitMigration[1], splitMigration[2]);

                            db.ExecuteNonQuery($"INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES('{migration}', '{productVersion}');");

                        }
                    }
                }
            }
        }
    }

    static List<string> ListPendingMigrations(Database db, List<string> migrationsJaExecutados)
    {
        var migrationsDisponiveis = Assembly.GetEntryAssembly().GetManifestResourceNames().Where(n => n.StartsWith("FluxoDeCaixa.Data.Scripts.") && n.EndsWith(".sql")).ToList();

        var migrationsPendentes = new List<string>();

        foreach ( var resource in migrationsDisponiveis )
        {
            string[] resSplit = resource.ToUpper().Split('.');
            if ( resSplit.Length >= 3 )
            {
                string migration = resSplit[2];
                if ( migrationsJaExecutados.Contains(migration) )
                {
                    Debug.WriteLine($"/!\\ {migration}: já executado neste banco!");
                    continue;
                }

                migrationsPendentes.Add(resource.Replace("FluxoDeCaixa.Data.Scripts.", "").Replace(".sql", ""));
            }
        }

        return migrationsPendentes;
    }

    static List<string> ListExecutedMigrations(Database db)
    {
        var executedMigrations = db.QueryList<object>("SELECT UPPER(MigrationId) AS RESULTADO FROM __EFMigrationsHistory ORDER BY MigrationId");
        return executedMigrations.Select(x => x.ToString()).ToList();
    }

    private static string AjustaScript(string script)
    {
        var _script = script;

        _script = QUEBRAS_DE_LINHA_E_PONTOEVIRGULA.Replace(_script, ";");

        //comenta todas as triggers...
        _script = _script.Replace("CREATE TRIGGER ", "/*CREATE TRIGGER ");
        _script = _script.Replace("END;", "END;*/");
        //... para depois removê-las, mas não conte a elas ok?

        //remove comentários de única linha
        _script = COMENTARIO_1_LINHA.Replace(_script, "");

        //remove comentários de múltiplas linhas
        _script = COMENTARIO_N_LINHAS.Replace(_script, "");

        //remove PRAGMA foreign_keys
        _script = PRAGMA_FOREIGN_KEYS.Replace(_script, "");

        //todo CREATE TABLE deve ser IF NOT EXISTS
        _script = _script.Replace("CREATE TABLE IF NOT EXISTS ", "CREATE TABLE ").Replace("CREATE TABLE ", "CREATE TABLE IF NOT EXISTS ");

        //todo CREATE INDEX deve ser IF NOT EXISTS
        _script = _script.Replace("CREATE INDEX IF NOT EXISTS ", "CREATE INDEX ").Replace("CREATE INDEX ", "CREATE INDEX IF NOT EXISTS ");

        //múltiplas colunas em apenas uma linha devem ser quebradas em múltiplas linhas
        _script = MULTIPLAS_COLUNAS_EM_1_LINHA.Replace(_script, ",\r\n    \"");

        //remoção default duplicado
        _script = _script.Replace("DEFAULT (0) DEFAULT 0", "DEFAULT(0)");

        //manter neste ponto, nescessario devido aos tratamentos anteriores
        _script = _script.Replace("));", ")\r\n);");

        //remoção das indicações de NOT NULL
        _script = NOT_NULL_SEM_DEFAULT.Replace(_script, m => m.Groups[1].Value); //, "$1");
        _script = NOT_NULL_COM_DEFAULT_E_PONTOEVIRGULA.Replace(_script, ";");
        _script = NOT_NULL_COM_DEFAULT_E_VIRGULA.Replace(_script, ",");
        _script = NOT_NULL_COM_DEFAULT.Replace(_script, "");

        //remoção das indicações de NULL (desnecessário)
        _script = NULL_COM_OU_SEM_VIRGULA.Replace(_script, m => m.Groups[1].Value); //, "$1");

        _script = VIRGULA_SOLITARIA.Replace(_script, ",\r\n"); //a vírgula solitária

        //remoção das CONSTRAINTS de chaves estrangeiras (não aplicáveis no contexto da sincronização legada)
        _script = CONSTRAINT.Replace(_script, "");

        //ajuste das vírgulas e quebras de linha que sobraram das substituições anteriores
        _script = VIRGULA_E_QUEBRAS_DE_LINHA.Replace(_script, ");");

        return _script;
    }
}
