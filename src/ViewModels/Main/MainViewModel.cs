using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxoDeCaixa.Mobile.Core.Data;
using FluxoDeCaixa.Mobile.Core.Domain.Entities;
using FluxoDeCaixa.Mobile.Models.Setup;

namespace FluxoDeCaixa.Mobile.ViewModels.Main;

public partial class MainViewModel : BaseViewModels
{
    [ObservableProperty]
    bool showLoading = true;

    [ObservableProperty]
    SetupModel model;

    public MainViewModel()
    {
        Model = new();
    }

    public async override void Load_Page()
    {

        if (Preferences.ContainsKey(nameof(Database)))
        {
            App.Current.MainPage = new NavigationPage(new Views.Pages.Dashboard.DashboardPage());
            return;
        }

        ShowLoading = false;
    }



    [RelayCommand]
    void InitDatabase()
    {
        try
        {
            Database database = new Database();


        }
        catch ( Exception ex )
        {

        }
    }

}
