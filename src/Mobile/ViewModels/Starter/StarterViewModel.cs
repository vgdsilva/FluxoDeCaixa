using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxoDeCaixa.Models.Starter;

namespace FluxoDeCaixa.ViewModels.Starter;

public partial class StarterViewModel : BaseViewModels
{
    [ObservableProperty]
    StarterModel dataModel;

    [ObservableProperty]
    bool isInstanceDatabase;

    public StarterViewModel()
    {
        DataModel = new();
        IsInstanceDatabase = false;
    }


    [RelayCommand]
    async Task Init()
    {
        try
        {
            IsInstanceDatabase = true;
            Core.Configuration.Factory.InitInstanceDatabase();
            await Task.Delay(2000);

            App.Current.MainPage = new AppShell();
        }
        catch ( Exception ex )
        {

        }
    }
}
