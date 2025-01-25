using FluxoDeCaixa.Domain.Enums;

namespace FluxoDeCaixa.MAUI.Pages.Transaction.Detail;

public partial class TransactionDetailModel : ObservableObject
{

    [ObservableProperty]
    string descricao;

    [ObservableProperty]
    decimal valor;

    [ObservableProperty]
    DateTime data;

    [ObservableProperty]
    TransactionTypeEnum tipo;

    public TransactionDetailModel()
    {
        
    }

    public static TransactionDetailModel InstanceNew(TransactionTypeEnum tipo)
    {
        return new TransactionDetailModel { Tipo = tipo };
    }
}
