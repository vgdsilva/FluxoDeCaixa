using FluxoDeCaixa.Mobile.Views.Pages.Home;

namespace FluxoDeCaixa.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Application.Current!.UserAppTheme = AppTheme.Light;

		MainPage = new HomePage();
	}
}
