using FluxoDeCaixa.MAUI.Pages.Base;

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
}
