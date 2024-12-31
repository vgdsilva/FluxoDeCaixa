namespace FluxoDeCaixa.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Pages.Login.LoginPage());
        }
    }
}
