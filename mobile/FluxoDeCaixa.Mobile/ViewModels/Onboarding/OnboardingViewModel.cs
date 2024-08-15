using FluxoDeCaixa.Mobile.Core.Data;

namespace FluxoDeCaixa.Mobile.ViewModels.Onboarding;

public partial class OnboardingViewModel : BaseViewModel
{
    


    public OnboardingViewModel()
    {
         
    }

    public override async void Page_Load()
    {
        try
        {
            IsBusy = true;

            await MobileContextUtil.Instance.InitInstanceDB();
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
