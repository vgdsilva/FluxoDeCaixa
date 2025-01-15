using FluxoDeCaixa.MAUI.Core.Utils.Classes;
using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Pages.Shell;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Pages.Login;

public partial class LoginViewModel : BaseViewModels
{


    [RelayCommand]
    async Task SignInWithMicrosoft()
    {
        await Execute.Task(async () =>
        {
            NavigationUtils.SetMainPage(new AppShell());
        });
    }
}