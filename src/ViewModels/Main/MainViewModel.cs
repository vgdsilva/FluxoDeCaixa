using CommunityToolkit.Mvvm.ComponentModel;
using FluxoDeCaixa.Mobile.Core.Data;

namespace FluxoDeCaixa.Mobile.ViewModels.Main;

public partial class MainViewModel : BaseViewModels
{
    [ObservableProperty]
    bool showLoading = true;

    public async override void Load_Page()
    {

        await Task.Delay(50000);

        if (Preferences.ContainsKey(nameof(Database)))
        {
            App.Current.MainPage = new NavigationPage(new Views.Pages.Dashboard.DashboardPage());
            return;
        }

        ShowLoading = false;

    }

}
