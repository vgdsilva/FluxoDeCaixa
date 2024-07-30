using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxoDeCaixa.Mobile.Domain.Models;

namespace FluxoDeCaixa.Mobile.ViewModels.Categoria;
public partial class CategoriaViewModel : BaseViewModel
{
    [ObservableProperty]
    CategoriaModel model;

    public CategoriaViewModel()
    {
        Title = "Nova Categoria";
        Model = new CategoriaModel();
    }

    [RelayCommand]
    async Task Save()
    {
        try
        {
            await GoToAsync("..");
        }
        catch (Exception ex)
        {
            
        }
    }
}
