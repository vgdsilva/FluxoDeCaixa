using CommunityToolkit.Mvvm.ComponentModel;

namespace FluxoDeCaixa.ViewModels;

public partial class BaseViewModels : ObservableObject
{

    public virtual void OnAppearing() { }

    public void ShowToast(string message)
    {
        CommunityToolkit.Maui.Alerts.Toast.Make(message).Show();
    }
}
