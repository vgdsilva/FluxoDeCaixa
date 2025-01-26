using FluxoDeCaixa.MAUI.Componentes;

namespace FluxoDeCaixa.MAUI.Pages.Base;

public partial class BasePages : ContentPage
{
    public BasePages()
    {
        HideSoftInputOnTapped = true;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as BaseViewModels)?.SetInstancePage(this);
        (BindingContext as BaseViewModels)?.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        (BindingContext as BaseViewModels)?.OnDisappearing();
    }
}



