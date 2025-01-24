namespace FluxoDeCaixa.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Application.Current!.UserAppTheme = AppTheme.Light;
            
            MainPage = new NavigationPage(new Pages.Onboarding.OnboardingPage());
        }
    }
}
