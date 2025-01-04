using FluxoDeCaixa.MAUI.Componentes;

namespace FluxoDeCaixa.MAUI.Pages.Base;

public abstract class BasePages<TViewModel> : PageView where TViewModel : BaseViewModels, new()
{
    public TViewModel? ViewModel => BindingContext as TViewModel;

    public BasePages()
    {
        BindingContext = new TViewModel();
    }

}

public partial class BaseViewModels : ObservableObject
{
    public BaseViewModels() { }
}

