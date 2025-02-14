using FluxoDeCaixa.MAUI.Componentes;
using FluxoDeCaixa.MAUI.Core.Utils.Classes;
using FluxoDeCaixa.MAUI.Utils.Classes;
using FluxoDeCaixa.MAUI.Utils.Validators;
using RGPopup.Maui.Pages;

namespace FluxoDeCaixa.MAUI.Views.Pages.Base;

public partial class BaseViewModels : ObservableObject
{
    public Page Page { get; private set; }

    /// <summary>
    /// Utilize para o controle de carregamento do OnAppearing() no ViewModel
    /// </summary>
    public bool IsLoadedViewModel;

    public T FindByName<T>(string name) => Page.FindByName<T>(name);
    public string Id { get; set; }


    const string callIDLoaging = "LOADING_TRANSICAO_TELAS";

    public BaseViewModels() { }


    #region OnAppearing
    public virtual async Task Init() { }

    public async Task BeforeOnAppearing()
    {
    }

    public async void OnAppearing()
    {
        try
        {
            await BeforeOnAppearing();

            await Init();

            await AfterOnAppearing();
        }
        catch (Exception ex) { OnAppearingException(ex); }
    }

    public async Task AfterOnAppearing()
    {
        await LoadingScreen.Instance.Stop(callIDLoaging);
    }

    public void OnAppearingException(Exception ex)
    {
    }
    #endregion


    #region OnDisappearing
    public virtual async Task End() { }

    public async Task BeforeOnDisappearing()
    {
    }

    public async void OnDisappearing()
    {
        //Faça suas implementações no método End

        try
        {
            await BeforeOnDisappearing();

            await End();

            await AfterOnDisappearing();
        }
        catch (Exception ex) { OnDisppearingException(ex); }
    }

    public async Task AfterOnDisappearing()
    {
        if (Page is PopupPage)
            await LoadingScreen.Instance.Stop(callIDLoaging);
        else
            await LoadingScreen.Instance.Start(callIDLoaging);
    }

    public void OnDisppearingException(Exception ex)
    {
    }
    #endregion




    public void SetInstancePage(Page page) => Page = page;

    protected bool ValidateForm(string dataFormGridName, bool showRequiredFieldsMessageError = false)
    {
        bool isFormValid = true;

        if (Page is null)
            throw new ArgumentNullException(nameof(Page));

        isFormValid = FormValidators.ValidateForm(Page, dataFormGridName);

        if (!isFormValid && showRequiredFieldsMessageError)
            MainThread.BeginInvokeOnMainThread(async () => await SnackBar.ShowError("Preencha os campos obrigatorios."));

        return isFormValid;
    }
}
