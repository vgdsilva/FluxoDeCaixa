
using FluxoDeCaixa.MAUI.Core.Utils.Classes;
using FluxoDeCaixa.MAUI.Utils.Validators;

namespace FluxoDeCaixa.MAUI.Pages.Base;

public partial class BaseViewModels : ObservableObject
{

    public Page Page { get; private set; }

    /// <summary>
    /// Utilize para o controle de carregamento do OnAppearing() no ViewModel
    /// </summary>
    public bool IsLoadedViewModel;

    public T FindByName<T>(string name) => Page.FindByName<T>(name);
    public string Id { get; set; }


    public BaseViewModels() { }

    public virtual void Init() { }

    public async void OnAppearing()
    {
        await Execute.Task(Init);
    }

    public virtual void End() { }

    public async void OnDisappearing()
    {
        await Execute.Task(End);
    }


    public void SetInstancePage(Page page) => this.Page = page;

    protected bool ValidateForm(string dataFormGridName)
    {
        bool isFormValid = true;

        if (Page is null)
            throw new ArgumentNullException(nameof(Page));

        isFormValid = FormValidators.ValidateForm(Page, dataFormGridName);

        //if (!isFormValid && showRequiredFieldsMessageError)
        //    MainThread.BeginInvokeOnMainThread(async () => DCToast.ShowInfo(TZ.MSG_PREENCHA_CAMPOS_OBRIGATORIOS(), 4));

        return isFormValid;
    }
}
