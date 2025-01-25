using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Onboarding;

public partial class OnboardingViewModel : BaseViewModels
{
    
    [ObservableProperty]
    IEnumerable<OnboardingModel> onboardings;

    public OnboardingViewModel()
    {
        onboardings = new List<OnboardingModel>();
    }

    public override void Init()
    {
        if (Configurations.Get(ConfigurationsEnum.HasInitialized, false))
        {
            NavigationUtils.SetMainPage(new NavigationPage(new Home.HomePage()));
            return;
        } 

        Onboardings = new[]
        {
            new OnboardingModel()
            {
                ImageSource = ImageSource.FromFile("onboarding_imagem1.png"),
                Title = "Bem-vindo ao aplicativo Fluxo de caixa",
                Subtitle = "Take control of your finances with easy and confidence"
            },
        };
    }

    [RelayCommand]
    async Task StartApp()
    {
        Configurations.Save(ConfigurationsEnum.HasInitialized, true);
        NavigationUtils.SetMainPage(new Home.HomePage());
    }
}
