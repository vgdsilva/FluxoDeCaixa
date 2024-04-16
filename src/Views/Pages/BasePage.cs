using FluxoDeCaixa.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Views.Pages;
public partial class BasePage : ContentPage
{


    protected override void OnAppearing()
    {
        base.OnAppearing();
        ( BindingContext as BaseViewModels )?.OnAppearing();
    }


}
