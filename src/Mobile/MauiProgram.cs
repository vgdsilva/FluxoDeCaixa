using FluxoDeCaixa.Core.Configuration;
using FluxoDeCaixa.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FluxoDeCaixa;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif


        builder.Services.AddDbContext<SQLiteContext>(options => options.UseSqlite($"Filname={Factory.databasePath}", x => x.MigrationsAssembly(nameof(FluxoDeCaixa.Data))));

        return builder.Build();
    }
}
