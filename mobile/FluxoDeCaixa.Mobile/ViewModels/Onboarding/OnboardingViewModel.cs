using FluxoDeCaixa.Mobile.Core.Data;

namespace FluxoDeCaixa.Mobile.ViewModels.Onboarding;

public partial class OnboardingViewModel : BaseViewModel
{
    public OnboardingViewModel()
    {
        IsBusy = true;    
    }

    public override async void Page_Load()
    {
        try
        {
            IsBusy = true;

            await MobileContextUtil.Instance.InitInstanceDB();
            
            if (MobileContextUtil.Instance.IsContextValid())
            {
                App.Current!.MainPage = new MainPage();
                return;
            }

        }
        catch ( Exception ex )
        {

        }
        finally
        {
            IsBusy = false;
        }

    }
}
