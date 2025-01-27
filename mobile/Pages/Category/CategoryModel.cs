using FluxoDeCaixa.Domain.Enums;
using FluxoDeCaixa.MAUI.Pages.Base;

namespace FluxoDeCaixa.MAUI.Pages.Category;

public partial class CategoryModel : BaseModels
{
    [ObservableProperty]
    string descricao;

    [ObservableProperty]
    string tipoTransacao;

    [ObservableProperty]
    List<String> tipoTransacoesList;

    [ObservableProperty]
    string icone;

    [ObservableProperty]
    string corIcone;

    public CategoryModel()
    {
        
    }
}
