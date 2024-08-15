using RGPopup.Maui.Pages;
using RGPopup.Maui.Services;

namespace FluxoDeCaixa.Mobile.Controls;

public partial class ToastPopup : PopupPage
{
    public static async Task ShowError(string message, int timeToCloseInSeconds = 8)
    {
        ToastBuilder builder = new ToastBuilder()
            .SetMessage(message)
            .SetModalBehavior(false)
            .SetBackgroundColor(Color.FromHex("#EF4444"));

        ToastPopup toast = builder.Build();

        await PopupNavigation.Instance.PushAsync(toast);

        await Task.Delay(timeToCloseInSeconds * 1000)
            .ContinueWith(_ => { toast.Close(); });
    }
}