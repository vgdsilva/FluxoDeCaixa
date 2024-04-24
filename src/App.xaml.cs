using FluxoDeCaixa.Mobile.Views.Pages.Dashboard;

namespace FluxoDeCaixa.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }
}
