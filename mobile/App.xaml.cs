using FluxoDeCaixa.Data.Repositories;

namespace FluxoDeCaixa.MAUI
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            Application.Current!.UserAppTheme = AppTheme.Light;

            RepositoryProvider.Initialize(serviceProvider);

            MainPage = new NavigationPage(new Pages.Onboarding.OnboardingPage());
        }
    }

    public static class RepositoryProvider
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public static CategoryRepository Category => _serviceProvider.GetRequiredService<CategoryRepository>();
        public static TransactionRepository Transaction => _serviceProvider.GetRequiredService<TransactionRepository>();

    }
}
