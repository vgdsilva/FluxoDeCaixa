using CommunityToolkit.Maui;
using DevExpress.Maui;
using Microsoft.Extensions.Logging;
using RGPopup.Maui.Extensions;

namespace FluxoDeCaixa.Mobile
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

                    fonts.AddFont("Quicksand-Light.ttf", "Quicksand300Font");
                    fonts.AddFont("Quicksand-Regular.ttf", "Quicksand400Font");
                    fonts.AddFont("Quicksand-Medium.ttf", "Quicksand500Font");
                    fonts.AddFont("Quicksand-SemiBold.ttf", "Quicksand600Font");
                    fonts.AddFont("Quicksand-Bold.ttf", "Quicksand700Font");

                    fonts.AddFont("FontAwesome6Brands.otf", "FontAwesomeBrands");
                    fonts.AddFont("FontAwesome6Regular.otf", "FontAwesomeRegular");
                    fonts.AddFont("FontAwesome6Solid.otf", "FontAwesomeSolid");
                })
                .UseMauiCommunityToolkit()
                .UseDevExpress()
                .UseDevExpressCollectionView()
                .UseDevExpressControls()
                .UseDevExpressEditors()
                .UseMauiRGPopup();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
