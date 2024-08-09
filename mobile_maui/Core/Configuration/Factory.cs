using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.AppCore.Configuration;

public class Factory
{

    public static Database GetDatabase(string ConnectionString) =>
        new Database(ConnectionString);
   
}
