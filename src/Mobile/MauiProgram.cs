using CommunityToolkit.Maui;
using DevExpress.Maui;
using FluxoDeCaixa.Core.Configuration;
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

                fonts.AddFont("Quicksand-Regular.ttf", "Quicksand400Font");
                fonts.AddFont("Quicksand-Medium.ttf", "Quicksand500Font");
                fonts.AddFont("Quicksand-SemiBold.ttf","Quicksand600Font");
                fonts.AddFont("Quicksand-Bold.ttf", "Quicksand700Font");
            })
            .UseDevExpress()
            .UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
