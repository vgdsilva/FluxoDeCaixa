using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Domain.Mappings;
using FluxoDeCaixa.MAUI.Core.Utils.Classes;
using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Category;

public partial class CategoryViewModel : BaseViewModels
{

    [ObservableProperty]
    CategoryModel model;

    public CategoryViewModel()
    {
        Model = new();
    }

    [RelayCommand]
    async Task SearchTipoTransacao()
    {
        Model.TipoTransacoesList = ["Renda", "Despesa", "Poupança"];
    }


    [RelayCommand]
    async Task Salvar()
    {
        await Execute.Task(async () =>
        {
            var entity = new Mapper().Map<CategoryModel, Categoria>(Model);

            await RepositoryProvider.Category.SaveAsync(entity);

            await NavigationUtils.GoBackAsync();
        });
    }
}
