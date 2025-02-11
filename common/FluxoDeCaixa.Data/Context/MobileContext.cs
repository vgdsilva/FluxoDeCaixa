using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data.Context
{
    public class MobileContext
    {
        private static MobileContext _Instance;
        public static MobileContext Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MobileContext();
                return _Instance;
            }
        }

        public MobileContext()
        {



        }

        public MobileContext(string databasePath, string Cultura = "pt-BR")
        {
            try
            {
                this.databasePath = databasePath;

                _Instance = this;

                //localizacao
                setUserLocale(Cultura);
            }
            catch (Exception ex)
            {

            }
        }

        public static void Initialize(string databasePath, string Cultura = "pt-BR")
        {
            _Instance = new MobileContext(databasePath, Cultura);
        }

        public string databasePath { get; set; }

        private string userLocale = "pt-BR";
        public string getUserLocale()
        {
            return userLocale;
        }

        public void setUserLocale(string value)
        {
            userLocale = value;
        }
    }
}
