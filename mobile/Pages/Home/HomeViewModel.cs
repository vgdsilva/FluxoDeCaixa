using FluxoDeCaixa.MAUI.Pages.Base;

namespace FluxoDeCaixa.MAUI.Pages.Home;

public partial class HomeViewModel : BaseViewModels
{
    [ObservableProperty]
    HomeModel model;


    public HomeViewModel()
    {
        Model = new ();

        
    }

    

    private async Task VerificaDatabase()
    {

    }
}
