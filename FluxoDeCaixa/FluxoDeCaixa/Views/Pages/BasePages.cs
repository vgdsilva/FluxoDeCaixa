namespace FluxoDeCaixa.Views.Pages;

public partial class BasePages : ContentPage
{

	public BasePages()
	{
        CreateNavigationBarComponents();
    }


    protected override void OnAppearing()
    {
        ( BindingContext as BaseViewModel )?.OnAppearing();

        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        ( BindingContext as BaseViewModel )?.OnDisappearing();
        base.OnDisappearing();
    }
}