using SQLite;

namespace FluxoDeCaixa.Data.Geral;

public class AtualizaDB
{
    private static int ultimaVersaoDisponivel = int.MaxValue;
    private static int versaoAtual { get; set; } = 0;

    public static void AtualizarBancoDeDados()
    {
        int versaoInicial = ObterVersaoInicial();

        versaoAtual = Math.Max(versaoInicial, 1445);

        while (versaoAtual < ultimaVersaoDisponivel)
        {
            ExecutaScriptsBanco();
        }
    }

    private static int ObterVersaoInicial()
    {
        string resultado = ExecuteScalar<string>("SELECT NAME AS RESULTADO FROM SQLITE_MASTER WHERE TYPE = 'table' AND NAME = 'VERSAO_BANCO'");

        if (resultado == null)
        {
            Executa(QueryBuilder.CreateTable("VERSAO_BANCO")
                                .AddPrimaryKey("VERSAO", "INTEGER")
                                .GenerateSQL());
            return 0;
        }

        resultado = ExecuteScalar<string>("SELECT CAST(VERSAO AS VARCHAR) AS RESULTADO FROM VERSAO_BANCO");
        if (resultado == null)
        {
            Executa(QueryBuilder.InsertInto("VERSAO_BANCO")
                                .AddField("VERSAO", 0)
                                .GenerateSQL());
            return 0;
        }

        return int.TryParse(resultado, out int versaoInicial) ? versaoInicial : versaoAtual;
    }

    private static void ExecutaScriptsBanco()
    {
        try
        {
            versaoAtual++;

            switch (versaoAtual)
            {
                default:
                    versaoAtual--;
                    ultimaVersaoDisponivel = versaoAtual;

                    Executa(QueryBuilder.Update("VERSAO_BANCO")
                                        .SetField("VERSAO", versaoAtual)
                                        .GenerateSQL());
                    break;

                case 1446:
                    // Insira aqui o código para executar os scripts da versão 1446
                    break;
            }
        }
        catch (Exception ex)
        {
            // Tratamento de exceções, se necessário
        }
    }

    static T ExecuteScalar<T>(string sql, object[] objects = null) where T : class
    {
        using (SQLQuery query = new SQLQuery(MobileContext.Instance.ConnectionString))
        {
            return query.ExecuteScalar<T>(sql, objects);
        }
    }

    static void Executa(string sql, object[] objects = null)
    {
        using (SQLiteConnection connection = new SQLiteConnection(MobileContext.Instance.ConnectionString))
        {
            string[] comandos = sql.Split(";");

            try
            {
                connection.BeginTransaction();  

                foreach (string comando in comandos)
                {
                    string comandoAux = comando.Trim();
                    if (string.IsNullOrEmpty(comandoAux))
                        continue;

                    connection.Execute(comandoAux);
                }

                connection.Commit();
            }
            catch (Exception ex)
            {
                connection.Rollback();
                throw ex;
            }           
        }
    }
}
