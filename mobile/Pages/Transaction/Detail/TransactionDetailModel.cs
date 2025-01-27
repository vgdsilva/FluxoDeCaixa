using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Domain.Enums;
using FluxoDeCaixa.MAUI.Pages.Base;

namespace FluxoDeCaixa.MAUI.Pages.Transaction.Detail;

public partial class TransactionDetailModel : BaseModels
{
    [ObservableProperty]
    string descricao;

    [ObservableProperty]
    decimal valor = 0;

    [ObservableProperty]
    DateTime data = DateTime.UtcNow;

    [NotifyPropertyChangedFor(nameof(IsDespesa))]
    [NotifyPropertyChangedFor(nameof(IsRenda))]
    [NotifyPropertyChangedFor(nameof(IsPoupanca))]
    [ObservableProperty]
    string tipo = "Despesa";

    public bool IsDespesa => Tipo?.ToLower().Equals("Despesa".ToLower()) ?? false;
    public bool IsRenda => Tipo?.ToLower().Equals("Renda".ToLower()) ?? false;
    public bool IsPoupanca => Tipo?.ToLower().Equals("Poupança".ToLower()) ?? false;


    [ObservableProperty]
    Guid categoriaId;

    [ObservableProperty]
    Categoria categoria;

    [ObservableProperty]
    List<Categoria> categoriasList;



    public TransactionDetailModel()
    {
        
    }


    [RelayCommand]
    void SetTipoTransacao(string tipo)
    {
        Tipo = tipo;
    }

    [RelayCommand]
    async void SearchCategoriesFromTipo()
    {
        CategoriasList = (await RepositoryProvider.Category.GetAllAsync()).Where(x => x.TipoTransacao == Tipo).ToList();
    }
}
