using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
            //await GoToAsync(nameof(CategoriaPage));
        }


        [RelayCommand]
        async Task AddTransacion()
        {
            //await App.Current.MainPage.Navigation.PushModalAsync(new Views.Pages.Transacao.TransacaoPopupPage());
        }
    }
}
