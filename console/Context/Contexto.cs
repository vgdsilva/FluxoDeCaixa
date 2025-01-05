namespace FluxoDeCaixa.Console.Context;

public class Contexto
{
    private static Contexto _instance;

    public static Contexto Instance
    {
        get
        {
            _instance ??= new Contexto();
            return _instance;
        }
    }


    public static string databasePath => Path.Combine(Directory.GetCurrentDirectory(), nameof(FluxoDeCaixa), "data");


    public Contexto()
    {
            
    }


    public static void AssignNewInstance()
    {
        _instance = new Contexto()
        {
            
        };
    }
}
