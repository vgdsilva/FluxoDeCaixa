using FluxoDeCaixa.Views.Pages.Starter;

namespace FluxoDeCaixa;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new StarterPage();
    }
}
