using FluxoDeCaixa.Mobile.Views.Pages.Dashboard;
using FluxoDeCaixa.Mobile.Views.Pages.Onboarding;

namespace FluxoDeCaixa.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new OnboardingPage();
        }
    }
}
