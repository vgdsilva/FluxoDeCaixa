using FluxoDeCaixa.Mobile.ViewModels.Dashboard;

namespace FluxoDeCaixa.Mobile.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
