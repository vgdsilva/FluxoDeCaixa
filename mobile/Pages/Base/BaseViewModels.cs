
using FluxoDeCaixa.MAUI.Core.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Base;

public partial class BaseViewModels : ObservableObject
{
    public BaseViewModels() { }

    public virtual void Init() { }

    public async void OnAppearing()
    {
        await Execute.Task(Init);
    }

    public virtual void End() { }

    public async void OnDisappearing()
    {
        await Execute.Task(End);
    }
}
