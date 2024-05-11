namespace FluxoDeCaixa.Mobile.ViewModels.Home;

public partial class HomeViewModel : BaseViewModels
{
    public override void Load_Page()
    {
        base.Load_Page();

        Core.Data.AppContext.Instance.InitInstanceDB();
    }
}
