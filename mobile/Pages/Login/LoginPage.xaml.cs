using FluxoDeCaixa.MAUI.Pages.Base;

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
    public override void Page_Load(object sender)
    {

    }
}