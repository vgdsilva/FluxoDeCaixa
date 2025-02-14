using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Pages.Transaction.Detail;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Transaction.List;

public partial class TransactionListViewModel : BaseViewModels
{
    [RelayCommand]
    async Task AddTransaction()
    {
        await NavigationUtils.GoToAsync(nameof(TransactionDetailPage));
    }
}
