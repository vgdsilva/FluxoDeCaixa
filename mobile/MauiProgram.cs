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
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

            builder
                .Services
                .AddInfrastructure("");
#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            Context.Initialize(app.Services);

            return app;
        }
    }
}