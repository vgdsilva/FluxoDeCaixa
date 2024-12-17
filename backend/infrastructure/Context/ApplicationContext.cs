namespace FluxoDeCaixa.Infrastructure.Context;

public class ApplicationContext
{
    public static ApplicationContext Instance { get; private set; }

    public string ConnectionString { get; private set; }

    public static void AssignNewInstance(string connectionString)
    {
        Instance = new ApplicationContext()
        {
            ConnectionString = connectionString
        };
    }
}
