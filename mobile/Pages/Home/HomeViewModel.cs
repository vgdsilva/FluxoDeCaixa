using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Pages.Transaction.Detail;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Home;

public partial class HomeViewModel : BaseViewModels
{

    public HomeViewModel()
    {

    }


    [RelayCommand]
    async Task AdicionarRenda()
    {
        await NavigationUtils.PushAsync<TransactionDetailPage>();
    }


    [RelayCommand]
    async Task AdicionarDespesa()
    {
        await NavigationUtils.PushModalAsync<TransactionDetailPage>();
    }
}
