using FluxoDeCaixa.Mobile.ViewModels.Settings;

namespace FluxoDeCaixa.Mobile.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
