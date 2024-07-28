using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxoDeCaixa.Mobile.Data.Repository;
using FluxoDeCaixa.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Domain.Entities.Categoria categoria = new Domain.Entities.Categoria()
            {
                Descricao = Model.Descricao,
            };

            await CategoriaRepository.Singleton.SaveChangesAsync(categoria);
            await GoToAsync("..");
        }
        catch (Exception ex)
        {
            
        }
    }
}
