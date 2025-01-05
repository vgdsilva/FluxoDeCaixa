using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.WinForms.Context
{
    public class AppContext
    {
        private static AppContext _instance;

        public static AppContext Instance
        {
            get
            {
                _instance ??= new AppContext();
                return _instance;
            }
        }

        public static string databasePath => Path.Combine(Directory.GetCurrentDirectory(), "_data");

        public AppContext()
        {

        }


        public static void Initialize()
        {
            _instance = new AppContext()
            {

            };
        }
    }


}
