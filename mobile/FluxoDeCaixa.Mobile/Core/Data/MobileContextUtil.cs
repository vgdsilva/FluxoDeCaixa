using FluxoDeCaixa.Data.Contexto;
using FluxoDeCaixa.Domain.Utils;
using System.Globalization;

namespace FluxoDeCaixa.Mobile.Core.Data;

public class MobileContextUtil
{
    private static MobileContextUtil _MobileContextUtil { get; set; }
    public static MobileContextUtil Instance => _MobileContextUtil ??= new MobileContextUtil();

    public static string GetFolderDatabasePath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DeviceInfo.Current.Platform == DevicePlatform.Android ? ".local/share" : string.Empty);

    public static string databasePath = Path.Combine(GetFolderDatabasePath(), "database.db");

    public async Task InitInstanceDB()
    {
        await Task.Run(() =>
        {
            if ( !FileUtils.FileExists(databasePath) )
            {
                FileUtils.CopyFromResourceIfNotExists(typeof(MobileContext), Path.GetFileName(databasePath), databasePath);
            }

            MobileContext.AssignNewInstance(databasePath, CultureInfo.CurrentCulture);

            FluxoDeCaixa.Data.Geral.AtualizaDB.AtualizarBancoDeDados();
        });
    }

    public bool IsContextValid()
    {
        return false;
    }
}
