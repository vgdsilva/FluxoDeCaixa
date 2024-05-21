using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxoDeCaixa.Features.OperationCategory;
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
        if ( Core.Configuration.Factory.ExistsDatabase() )
            App.Current.MainPage = new AppShell();

        DataModel = new();
        IsInstanceDatabase = false;
    }

    public override void OnAppearing()
    {
        try
        {
            if (Core.Configuration.Factory.ExistsDatabase())
            {
                Task.Run(Core.Configuration.Factory.CreateDatabaseConfiguration().SynchronizeTables);
                Task.Delay(1000);

                App.Current.MainPage = new AppShell();
            }
        }
        catch (Exception ex)
        {
            ShowToast(ex.Message);
        }
    }


    [RelayCommand]
    async Task Init()
    {
        try
        {
            IsInstanceDatabase = true;
            await Task.Run(Core.Configuration.Factory.InitInstanceDatabase);
            await Task.Delay(1000);

            App.Current.MainPage = new AppShell();
        }
        catch ( Exception ex )
        {
            ShowToast(ex.Message);
            IsInstanceDatabase = false;
        }
    }
}
