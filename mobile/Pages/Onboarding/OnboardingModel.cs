namespace FluxoDeCaixa.MAUI.Pages.Onboarding;

public partial class OnboardingModel : ObservableObject
{
    [ObservableProperty]
    private ImageSource _imageSource;
    
    [ObservableProperty]
    private string _title;
    
    [ObservableProperty]
    private string _subtitle;
}