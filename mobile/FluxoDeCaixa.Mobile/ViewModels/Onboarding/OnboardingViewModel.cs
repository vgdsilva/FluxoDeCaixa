using FluxoDeCaixa.Data.Repository;
using FluxoDeCaixa.Mobile.Controls;
using FluxoDeCaixa.Mobile.Core.Data;
using FluxoDeCaixa.Mobile.Views.Pages.Dashboard;

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
            
            if (FluxodecaixaRepository.Instance.ExistsFluxoDeCaixa())
            {
                App.Current!.MainPage = new DashboardPage();
                return;
            }

        }
        catch ( Exception ex )
        {
            await ToastPopup.ShowError(ex.Message, 4);
        }
        finally
        {
            IsBusy = false;
        }

    }
}
