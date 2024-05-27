using Microsoft.Extensions.Logging;

namespace FluxoDeCaixaPessoal;
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

                fonts.AddFont("fa-brands-400.ttf", "FA-Brand");
                fonts.AddFont("fa-regular-400", "FA-Regular");
                fonts.AddFont("fa-solid-900", "FA-Solid");

                fonts.AddFont("Quicksand-Bold.ttf", "Quicksand-Bold");
                fonts.AddFont("Quicksand-Semibold.ttf", "Quicksand-Semibold");
                fonts.AddFont("Quicksand-Medium.ttf", "Quicksand-Medium");
                fonts.AddFont("Quicksand-Regular.ttf", "Quicksand-Regular");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
