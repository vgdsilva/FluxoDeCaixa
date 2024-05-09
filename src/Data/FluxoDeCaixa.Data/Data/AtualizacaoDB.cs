namespace FluxoDeCaixa.Data.Data;

public class AtualizacaoDB
{

    static string scriptAtual { get; set; } = "";

    public static void AtualizaBancoDeDados(Database db)
    {
        var ScriptInicial = "V1_0_0_Inicial";

        var resultado = db.Query<Object>("SELECT name FROM sqlite_master WHERE type='table' AND name='ScriptHistory'");
    }
}
