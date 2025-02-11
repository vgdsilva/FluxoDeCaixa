using FluxoDeCaixa.Data.Context;
using FluxoDeCaixa.MAUI.Pages.Shell;

namespace FluxoDeCaixa.MAUI
{
    public partial class App : Application
    {
        public static string databasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DeviceInfo.Current.Platform == DevicePlatform.Android ? ".local/share" : string.Empty, "database.db");

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            Application.Current!.UserAppTheme = AppTheme.Light;

            RepositoryProvider.Initialize(serviceProvider);

            MobileContext.Initialize(databasePath);

            //MainPage = new NavigationPage(new Pages.Onboarding.OnboardingPage());
            MainPage = new AppShell();
        }
    }

    public static class RepositoryProvider
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        //public static CategoryRepository Category => _serviceProvider.GetRequiredService<CategoryRepository>();
        //public static TransactionRepository Transaction => _serviceProvider.GetRequiredService<TransactionRepository>();

    }
}
