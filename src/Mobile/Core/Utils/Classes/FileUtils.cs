using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Utils.Classes
{
    public static class FileUtils
    {
        public static void CreateFile(Type type, string resourceName, string destinationPath)
        {
            if (!File.Exists(destinationPath))
            {
                Assembly assembly = type.GetTypeInfo().Assembly;
                //var pathAssembly = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(resourceName));

                using ( BinaryWriter bw = new BinaryWriter(new FileStream(destinationPath, FileMode.Create)) )
                {
                    byte[] buffer = new byte[2048];
                    int length = 0;

                }
            }
        }
    }
}
