﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Utils;

public class FileUtils
{
    public static void CopyFromResourceIfNotExists(Type type, string resourceName, string destinationPath)
    {
        if ( !FileExists(destinationPath) )
        {
            Assembly defaultAssembly = type.GetTypeInfo().Assembly;
            var pathAssembly = defaultAssembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(resourceName));

            if ( pathAssembly == null )
                throw new Exception($"Resource {resourceName} não existe.");

            using ( var br = defaultAssembly.GetManifestResourceStream(pathAssembly) )
            {
                using ( var bw = new BinaryWriter(new FileStream(destinationPath, FileMode.Create)) )
                {
                    byte[] buffer = new byte[2048];
                    int length = 0;
                    while ( ( length = br.Read(buffer, 0, buffer.Length) ) > 0 )
                    {
                        bw.Write(buffer, 0, length);
                    }
                }
            }
        }
    }

    public static bool FileExists(string filePath)
    {
        if ( File.Exists(filePath) )
            return true;
        return false;
    }
}
