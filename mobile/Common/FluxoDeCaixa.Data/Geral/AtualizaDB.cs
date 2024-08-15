using FluxoDeCaixa.Data.Contexto;
using SQLite;

namespace FluxoDeCaixa.Data.Geral;

public class AtualizaDB
{
    private static int ultimaVersaoDisponivel = int.MaxValue;
    private static int versaoAtual { get; set; } = 0;

    public static void AtualizarBancoDeDados()
    {
        int versaoInicial = 0;

        var resultado = ExecuteScalar<string>("SELECT NAME AS RESULTADO FROM SQLITE_MASTER WHERE TYPE = LOWER('TABLE') AND LOWER(NAME) = LOWER('VERSAO_BANCO')");
        if ( resultado == null ) //se a tabela ainda não existe, cria e insere o registro
        {
            Executa("CREATE TABLE VERSAO_BANCO (VERSAO INTEGER)");
            Executa($"INSERT INTO VERSAO_BANCO (VERSAO) VALUES ({versaoInicial})");
        }
        else
        {   
            //se já existe registro, pega o valor do campo
            resultado = ExecuteScalar<string>("SELECT CAST(VERSAO AS VARCHAR) AS RESULTADO FROM VERSAO_BANCO", new object[] { });
            if ( resultado == null )
            {
                //cria registro com a versão inicial
                Executa($"INSERT INTO VERSAO_BANCO (VERSAO) VALUES ({versaoInicial})");
            }
            else
            {
                if (!int.TryParse(resultado, out versaoInicial))
                    versaoInicial = versaoAtual;
            }
        }

        versaoAtual = Math.Max(versaoInicial, 1445);

        while (versaoAtual < ultimaVersaoDisponivel)
        {
            ExecutaScriptsBanco();
        }
    }

    private static void ExecutaScriptsBanco()
    {
        try
        {
            versaoAtual++;
            switch ( versaoAtual )
            {
                default:
                    versaoAtual--;
                    ultimaVersaoDisponivel = versaoAtual;
                    break;

                case 1446:

                    break;
            }
        }
        catch ( Exception ex )
        {

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
        using (SQLQuery query = new SQLQuery(MobileContext.Instance.ConnectionString))
        {
            string[] comandos = sql.Split(";");

            foreach (string comando in comandos)
            {
                string comandoAux = comando.Trim();
                if (string.IsNullOrEmpty(comandoAux))
                    continue;

                query.ExecuteNonQuery(comandoAux);
            }
        }
    }
}
