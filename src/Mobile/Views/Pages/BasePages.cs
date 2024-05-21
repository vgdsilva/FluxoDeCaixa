using FluxoDeCaixa.ViewModels;

namespace FluxoDeCaixa.Views.Pages;

public partial class BasePages : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ( BindingContext as BaseViewModels )?.OnAppearing();
    }
}
