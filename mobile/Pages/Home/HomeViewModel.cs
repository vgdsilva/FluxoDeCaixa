using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Pages.Settings;
using FluxoDeCaixa.MAUI.Pages.Transaction.Detail;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Home;

public partial class HomeViewModel : BaseViewModels
{
    [ObservableProperty]
    HomeModel model;


    public HomeViewModel()
    {
        Model = new ();
    }


    [RelayCommand]
    async void OpenSettingsPage()
    {
        await NavigationUtils.GoToAsync(nameof(SettingsPage));
    }

    [RelayCommand]
    async void AddNewTransaction()
    {
        await NavigationUtils.GoToAsync(nameof(TransactionDetailPage));
    }
}
