using Microsoft.Extensions.Logging;

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
                    fonts
                        //.AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                        //.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold")
                        .AddFont("Mulish-Bold.ttf", "MulishBold");
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            return app;
        }
    }
}