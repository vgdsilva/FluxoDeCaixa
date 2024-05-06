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
        ( BindingContext as BaseViewModels )?.Load_Page();
    }

    public static void RegistrarPage()
    {
        // Obtém o Type da classe que chama o método
        Type callingType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
        // Obtém o nome da classe que chama o método
        string callingTypeName = callingType.Name;

        Console.WriteLine($"Página '{callingTypeName}' registrada!");
        Console.ReadLine();

        Routing.RegisterRoute(callingTypeName, callingType);
    }

    public static async void GoToAsync(bool animate = true, IDictionary<string, object> parameters = null)
    {
        // Obtém o Type da classe que chama o método
        Type? callingType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
        if ( callingType is null )
            return;

        if ( parameters is null )
            parameters = new Dictionary<string, object>();

        // Obtém o nome da classe que chama o método
        string callingTypeName = callingType.Name;

        Console.WriteLine($"indo até Página '{callingTypeName}'");
        Console.ReadLine();

        await Shell.Current.GoToAsync(callingTypeName, animate, parameters);
    }

}
