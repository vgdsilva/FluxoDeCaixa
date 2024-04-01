using FluxoDeCaixa.Views.Pages;

namespace FluxoDeCaixa.Views;

public partial class MainPage : BasePages
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
