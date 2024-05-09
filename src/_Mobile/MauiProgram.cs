using CommunityToolkit.Maui;
using DevExpress.Maui;
using FluxoDeCaixa.Mobile.Core.Data;

namespace FluxoDeCaixa.Mobile;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("Quicksand-Bold.ttf", "QuicksandBold");
                fonts.AddFont("Quicksand-SemiBold.ttf", "QuicksandSemiBold");
                fonts.AddFont("Quicksand-Medium.ttf", "QuicksandMedium");
                fonts.AddFont("Quicksand-Regular.ttf", "QuicksandRegular");

                fonts.AddFont("FontAwesomeSolid6.ttf", "FontAwesomeSolid");
            })
            .UseDevExpress();

        return builder.Build();
    }
}
