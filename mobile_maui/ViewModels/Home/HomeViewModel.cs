using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxoDeCaixa.Mobile.Views.Pages.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.ViewModels.Home
{
    public partial class HomeViewModel : BaseViewModel
    {

        [ObservableProperty]
        DateTime currentDate;

        public HomeViewModel()
        {
            CurrentDate = DateTime.Now;
        }


        [RelayCommand]
        async Task ChangeCurrentDate()
        {
            
        }


        [RelayCommand]
        async Task AddCategoria()
        {
            await GoToAsync(nameof(CategoriaPage));
        }
    }
}
