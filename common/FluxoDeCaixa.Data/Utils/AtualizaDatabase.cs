using FluxoDeCaixa.Data.Context;
using FluxoDeCaixa.Data.Persistence;

namespace FluxoDeCaixa.Data.Utils;

public class AtualizacaoDB
{
    private static int ultimaVersaoDisponivel = int.MaxValue;
    private static int versaoAtual { get; set; } = 0;

    public static void AtualizaBancoDeDados(Action Processo)
    {
        int versaoInicial = 0;

        object? ExecuteScalar(string sql)
        {
            using (SQLiteDatabase db = new SQLiteDatabase(MobileContext.Instance.databasePath))
            {
                return db.ExecuteScalar(sql);
            }
        }
        
        void Executa(string sql)
        {
            using (SQLiteDatabase db = new SQLiteDatabase(MobileContext.Instance.databasePath))
            {
                db.Execute(sql);
            }
        }

        var resultado = ExecuteScalar("SELECT NAME AS RESULTADO FROM SQLITE_MASTER WHERE TYPE = LOWER('TABLE') AND LOWER(NAME) = LOWER('VERSAO_BANCO')");
        if (resultado == null)
        {
            Executa("CREATE TABLE VERSAO_BANCO (VERSAO INTEGER)");
            Executa($"INSERT INTO VERSAO_BANCO (VERSAO) VALUES ({versaoInicial})");
        }
        else
        {
            resultado = ExecuteScalar("SELECT CAST(VERSAO AS VARCHAR) AS RESULTADO FROM VERSAO_BANCO");
            if (resultado == null)
            {
                //cria registro com a versão inicial
                Executa($"INSERT INTO VERSAO_BANCO (VERSAO) VALUES ({versaoInicial})");
            }
            else
            {
                if (!int.TryParse(resultado.ToString(), out versaoInicial))
                    versaoInicial = versaoAtual;
            }
        }

        versaoAtual = Math.Max(versaoInicial, 1445);

        while (versaoAtual < ultimaVersaoDisponivel)
        {
            ExecutaScript();

            Executa($"UPDATE VERSAO_BANCO SET VERSAO = {versaoAtual}");
        }
    }

    private static void ExecutaScript()
    {
        void Executa(string sql)
        {
            using (SQLiteDatabase db = new SQLiteDatabase(MobileContext.Instance.databasePath))
            {
                db.Execute(sql);
            }
        }

        try
        {
            versaoAtual++;
            switch (versaoAtual)
            {
                default:
                    versaoAtual--;
                    ultimaVersaoDisponivel = versaoAtual;
                    break;

                case 1446:
                    Executa("");
                    break;
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }



}
