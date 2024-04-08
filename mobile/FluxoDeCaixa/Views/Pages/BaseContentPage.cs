using FluxoDeCaixa.ViewModels;

namespace FluxoDeCaixa.Views.Pages;


public class BaseContentPage : ContentPage
{
	public BaseContentPage()
	{
				
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ( BindingContext as BaseViewModels )?.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        ( BindingContext as BaseViewModels )?.OnDisappearing();

        base.OnDisappearing();
    }
}