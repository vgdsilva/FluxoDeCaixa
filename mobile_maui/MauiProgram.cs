using CommunityToolkit.Maui;
using DevExpress.Maui;
using Microsoft.Extensions.Logging;

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
                })
                .UseMauiCommunityToolkit()
                .UseDevExpress()
                .UseDevExpressCollectionView()
                .UseDevExpressControls()
                .UseDevExpressEditors();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
