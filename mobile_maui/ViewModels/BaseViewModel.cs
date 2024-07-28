using CommunityToolkit.Mvvm.ComponentModel;

namespace FluxoDeCaixa.Mobile.ViewModels
{

    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;



        protected async Task GoToAsync(ShellNavigationState state, bool animate = true)
        {
            await Shell.Current.GoToAsync(state, animate);
        }
    }
}
