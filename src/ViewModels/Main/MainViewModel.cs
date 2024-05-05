using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluxoDeCaixa.Mobile.Core.Data;
using FluxoDeCaixa.Mobile.Core.Domain.Entities;
using FluxoDeCaixa.Mobile.Models.Setup;

namespace FluxoDeCaixa.Mobile.ViewModels.Main;

public partial class MainViewModel : BaseViewModels
{
    [ObservableProperty]
    bool showLoading = true;

    [ObservableProperty]
    SetupModel model;

    [ObservableProperty]
    string titleQuestion;

    [ObservableProperty]
    string subTitleQuestion;

    [ObservableProperty]
    string principalButtonText;

    public MainViewModel()
    {
        Model = new();
        TitleQuestion = "";
        SubTitleQuestion = null;
        PrincipalButtonText = "Proximo";
    }

    public async override void Load_Page()
    {

        if (Core.Data.AppContext.Instance.IsValidContext())
        {
            App.Current.MainPage = new NavigationPage(new Views.Pages.Dashboard.DashboardPage());
            return;
        }
    }

    [RelayCommand]
    void CreateNewUser()
    {
        try
        {
            Model.ScreenType = SetupView.StartLogin;
            ShowNameStage();
        }
        catch ( Exception ex )
        {

        }
    }

    [RelayCommand]
    void LoginStageNext()
    {
        try
        {
            switch ( Model.LoginStage )
            {
                default:
                case StartLoginStage.Name:
                    ShowCurrencyStage();
                    break;
                case StartLoginStage.Currency:
                    ShowAmmountStage();
                    break;
                case StartLoginStage.Ammount:
                    ShowConfirmInfoStage();
                    break;
                case StartLoginStage.ConfirmInfo:

                    App.Current.MainPage = new AppShell();
                    break;
            }
        }
        catch ( Exception ex )
        {

        }
    }


    [RelayCommand]
    void LoginStagePrevious()
    {
        try
        {
            switch ( Model.LoginStage )
            {
                default:
                case StartLoginStage.Currency:
                    ShowNameStage();
                    break;
                case StartLoginStage.Ammount:
                    ShowCurrencyStage();
                    break;
                case StartLoginStage.ConfirmInfo:
                    ShowAmmountStage();
                    break;
            }
        }
        catch ( Exception ex )
        {

        }
    }

    void ShowNameStage()
    {
        Model.LoginStage = StartLoginStage.Name;
        PrincipalButtonText = "Proximo";
        TitleQuestion = "Como gostaria de ser chamado(a) ?";
        SubTitleQuestion = null;
    }

    void ShowCurrencyStage()
    {
        Model.LoginStage = StartLoginStage.Currency;
        PrincipalButtonText = "Proximo";
        TitleQuestion = "Selecione a sua moeda de uso";
        SubTitleQuestion = "Todas as transações serão calculadas com base na moeda que selecionou.";
    }

    void ShowAmmountStage()
    {
        Model.LoginStage = StartLoginStage.Ammount;
        PrincipalButtonText = "Proximo";
        TitleQuestion = "Insira seu saldo em dinheiro";
        SubTitleQuestion = "Quando de dinheiro você possui no momento?";
    }

    void ShowConfirmInfoStage()
    {
        Model.LoginStage = StartLoginStage.ConfirmInfo;
        PrincipalButtonText = "Confirmar";
        TitleQuestion = "Verifique os seus dados";
        SubTitleQuestion = "Confirme se estes são os dados corretos.";
    }

}
