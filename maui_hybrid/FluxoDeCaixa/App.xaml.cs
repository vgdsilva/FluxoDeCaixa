using FluxoDeCaixa.Views.Pages.Onboarding;

namespace FluxoDeCaixa;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new OnboardingPage();
    }
}
