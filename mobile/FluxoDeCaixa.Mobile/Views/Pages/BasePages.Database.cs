using FluxoDeCaixa.Data.contexto;
using FluxoDeCaixa.Mobile.Core.Utils.Extensions;
using FluxoDeCaixa.Mobile.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Input;

namespace FluxoDeCaixa.Mobile.Views.Pages;

public partial class BasePages : ContentPage
{
    
    //public void InicializaContextDatabaseApp(CultureInfo cultureInfo = null)
    //{
    //    string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    //    string pathDatabase = Path.Combine(path, "database.db");

    //    SetupBancoDeDados(typeof(App), "databaseSample.db", pathDatabase);

    //    //Iniciar Contexto
    //    new MobileContext(pathDatabase, cultureInfo?.Name ?? "pt-BR");
    //}

    //public void SetupBancoDeDados(Type type, string resourceName, string destinationPath)
    //{
    //    if (!File.Exists(destinationPath))
    //    {
    //        Assembly defaultAssembly = type.GetTypeInfo().Assembly;
    //        var pathAssembly = defaultAssembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(resourceName));

    //        if ( pathAssembly == null )
    //            throw new Exception($"Resource {resourceName} não existe.");

    //        using ( var br = defaultAssembly.GetManifestResourceStream(pathAssembly) )
    //        {
    //            using ( var bw = new BinaryWriter(new FileStream(destinationPath, FileMode.Create)) )
    //            {
    //                byte[] buffer = new byte[2048];
    //                int length = 0;
    //                while ( ( length = br.Read(buffer, 0, buffer.Length) ) > 0 )
    //                {
    //                    bw.Write(buffer, 0, length);
    //                }
    //            }
    //        }
    //    }
    //}

}