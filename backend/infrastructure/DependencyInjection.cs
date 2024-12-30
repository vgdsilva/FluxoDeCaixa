using FluxoDeCaixa.Infrastructure.Configuraction;
using FluxoDeCaixa.Infrastructure.Controller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDeCaixa
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            DataRow rootUser = new(Guid.Empty.ToString());

            rootUser["name"] = "root";
            rootUser["email"] = "root";
            rootUser["password"] = "123";


            DatabaseConfig config = new DatabaseConfig()
                .AddTableWithInitialData("Users", rootUser);

            using (Database db = ConnectionFactory.GetDatabase())
            {
                db.InitializeDatabase(config);

                db.SaveChanges();
            }
        }
    }
}
