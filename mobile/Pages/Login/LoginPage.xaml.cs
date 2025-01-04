using AndroidX.Navigation.UI;
using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Utils.Classes;
using FluxoDeCaixa.MAUI.Utils.Enums;
using System.Windows.Input;

namespace FluxoDeCaixa.MAUI.Pages.Login;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

		BindingContext = new LoginViewModel();
	}
}

public partial class LoginViewModel : BaseViewModels
{

	[ObservableProperty]
	string headlineTile;

    [ObservableProperty]
    string headlineSubTitle;

    public LoginViewModel()
    {
        HeadlineTile = "Bem-vindo(a)";
        HeadlineSubTitle = "O Fluxo de caixa � um aplicativo de gest�o financeira que utiliza IA para monitorar suas movimenta��es, e oferecer insights personalizados, facilitando o controle do seu or�amento.";
    }

    public override void Page_Load(object sender)
    {

    }

    [RelayCommand]
    async Task Start()
    {
        await NavigationUtils.PushAsync(new UserRegistrationPage());
    }

    
}