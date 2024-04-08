
namespace FluxoDeCaixa.Mobile.Views.Pages;

public partial class BasePage : ContentPage
{
    static Page CurrentPage = new Page();

	public BasePage()
	{
        InitializeComponent();
        CurrentPage = thisPage;
	}

    public static void NavigateTo()
    {
        App.Current.MainPage.Navigation.PushAsync(CurrentPage);
    }

    public static async Task GoToAsync()
    {
        await Shell.Current.GoToAsync(nameof(CurrentPage));
    }
}