using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infrastructure.Context
{
    public class SessionContext
    {
        public static SessionContext Instance { get; private set; }

        public string ConnectionString { get; private set; }

        public static void AssignNewInstance(string connectionString)
        {
            Instance = new SessionContext()
            {
                ConnectionString = connectionString
            };
        }
    }
}
