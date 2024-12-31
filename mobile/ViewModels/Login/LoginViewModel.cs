using FluxoDeCaixa.MAUI.Core.Utils.Classes;

namespace FluxoDeCaixa.MAUI.ViewModels.Login
{
    public partial class LoginViewModel : BaseViewModels
    {

        [ObservableProperty]
        bool showStartScreen = true;
        
        [ObservableProperty]
        bool showUserRegistrerScreen = false;

        [ObservableProperty]
        bool showCashFlowRegistrerScreen = false;
        public LoginViewModel()
        {
            
        }

        public override void Init() { }

        public override void End() { }


        [RelayCommand]
        async Task Start()
        {
            await Execute.Task(async () =>
            {
                ChangeScreen();
            });
        }

        void ChangeScreen()
        {
            if (ShowStartScreen)
            {
                ShowStartScreen = false;
                ShowUserRegistrerScreen = true;
                ShowCashFlowRegistrerScreen = false;
            }

            if (ShowUserRegistrerScreen)
            {
                ShowStartScreen = false;
                ShowUserRegistrerScreen = false;
                ShowCashFlowRegistrerScreen = true;
            }
        }
    }
}
