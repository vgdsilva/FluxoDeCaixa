using FluxoDeCaixa.Mobile.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace FluxoDeCaixa.Mobile.Views.Pages;

public partial class BasePages : ContentPage
{
    
    public BasePages()
	{
        //ChildAdded += BasePages_CreatePage;  
        
        On<iOS>().SetUseSafeArea(true);
        HideSoftInputOnTapped = true;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as BaseViewModel)?.SetInstancePage(this);
        (BindingContext as BaseViewModel)?.Page_Load();

        //SetNavigationBar();
    }


}