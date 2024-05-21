using CommunityToolkit.Maui;
using DevExpress.Maui;
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

                fonts.AddFont("Quicksand-Regular.ttf", "Quicksand-Regular");
                fonts.AddFont("Quicksand-Medium.ttf", "Quicksand-Medium");
                fonts.AddFont("Quicksand-SemiBold.ttf","Quicksand-SemiBold");
                fonts.AddFont("Quicksand-Bold.ttf", "Quicksand-Bold");
            })
            .UseDevExpress()
            .UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
