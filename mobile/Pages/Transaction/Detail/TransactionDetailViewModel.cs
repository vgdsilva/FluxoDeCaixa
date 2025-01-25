using FluxoDeCaixa.Domain.Enums;
using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Transaction.Detail;

public partial class TransactionDetailViewModel : BaseViewModels
{
    [ObservableProperty]
    TransactionDetailModel model;

    public TransactionDetailViewModel()
    {
        Model = new();
    }

    public override async void Init()
    {
        base.Init();

        
    }


}
