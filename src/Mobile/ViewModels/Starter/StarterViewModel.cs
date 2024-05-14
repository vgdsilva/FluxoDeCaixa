using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxoDeCaixa.Models.Starter;

namespace FluxoDeCaixa.ViewModels.Starter;

public partial class StarterViewModel : BaseViewModels
{
    [ObservableProperty]
    StarterModel dataModel;

    public StarterViewModel()
    {
        DataModel = new();
    }


    [RelayCommand]
    async Task Init()
    {

    }
}
