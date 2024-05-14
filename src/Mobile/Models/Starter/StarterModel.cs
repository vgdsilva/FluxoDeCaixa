using CommunityToolkit.Mvvm.ComponentModel;

namespace FluxoDeCaixa.Models.Starter;

public partial class StarterModel : ObservableValidator
{

    [ObservableProperty]
    string name = string.Empty;

    [ObservableProperty]
    decimal balance = 0;
}
