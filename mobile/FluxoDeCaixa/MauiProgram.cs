using CommunityToolkit.Maui;

namespace FluxoDeCaixa;

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
                //FontAwesome
                fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
                fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
                fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");

                //OpenSans
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                //Quicksand
                fonts.AddFont("Quicksand-Regular.ttf", "Quicksand400Font");
                fonts.AddFont("Quicksand-Medium.ttf", "Quicksand500Font");
                fonts.AddFont("Quicksand-SemiBold.ttf", "Quicksand600Font");
                fonts.AddFont("Quicksand-Bold.ttf", "Quicksand700Font");
            });

        return builder.Build();
    }
}
