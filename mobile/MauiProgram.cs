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
                    fonts.AddFont("Mulish-Bold.ttf", "MulishBold");

                    fonts.AddFont("FontAwesome6Brands.otf", "FontAwesomeBrands");
                    fonts.AddFont("FontAwesome6Regular.otf", "FontAwesomeRegular");
                    fonts.AddFont("FontAwesome6Solid.otf", "FontAwesomeSolid");
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            return builder.Build();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log ou manipulação da exceção
            var exception = e.ExceptionObject as Exception;
            string message = exception?.Message ?? "Exceção desconhecida";

            // Exemplo: Gravar log ou exibir mensagem de erro
            System.Diagnostics.Debug.WriteLine($"Erro não tratado: {message}");

            // Opção: Notificar o usuário
            // Note: Para mostrar mensagens na UI, use `MainThread` para garantir o acesso seguro à UI Thread.
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Application.Current?.MainPage?.DisplayAlert("Erro", message, "OK");
            });

            // Encerrar o aplicativo se necessário (cuidado com a experiência do usuário)
            if (e.IsTerminating)
            {
                System.Diagnostics.Debug.WriteLine("O aplicativo será encerrado devido a uma exceção fatal.");
            }
        }
    }
}