using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FluxoDeCaixa.Infrastructure.SQLite;
using FluxoDeCaixa.MAUI.Core.Data;

namespace FluxoDeCaixa.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp
                .CreateBuilder()
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                        .AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
                        .AddFont("Mulish-Bold.ttf", "MulishBold");
                });

            builder
                .Services
                .AddInfrastructure($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "database.db")}");
#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            Core.Data.AppContext.Initialize(app.Services);

            return app;
        }
    }
}