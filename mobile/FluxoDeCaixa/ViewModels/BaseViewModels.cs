using CommunityToolkit.Mvvm.ComponentModel;

namespace FluxoDeCaixa.ViewModels;

public partial class BaseViewModels : ObservableObject
{

    public BaseViewModels()
    {
        
    }

    public virtual void OnAppearing() { }
    public virtual void OnDisappearing() { }
}
