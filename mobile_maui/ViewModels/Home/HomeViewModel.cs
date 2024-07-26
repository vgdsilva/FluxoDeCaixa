using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            await App.Current.MainPage.DisplayAlert("Teste", CurrentDate.ToString(), "Ok");
        }
    }
}
