namespace FluxoDeCaixa.MAUI.Pages.Base;

public partial class BasePages : ContentPage
{

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as BaseViewModels)?.Page_Load(this);
    }
}

public abstract partial class BaseViewModels : ObservableObject
{
    public BaseViewModels() { }

    public abstract void Page_Load(object sender);
}

