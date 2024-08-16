using RGPopup.Maui.Pages;
using RGPopup.Maui.Services;

namespace FluxoDeCaixa.Mobile.Controls;

public partial class ToastPopup : PopupPage
{
    public static async Task ShowPrimaryToast(string message, int timeToCloseInSeconds = 8)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            ToastBuilder builder = new ToastBuilder()
                .SetMessage(message)
                .SetModalBehavior(false)
                .SetBackgroundColor(Color.FromHex("#0073EA"));

            ToastPopup toast = builder.Build();

            await PopupNavigation.Instance.PushAsync(toast);

            await Task.Delay(timeToCloseInSeconds * 1000)
                .ContinueWith(_ => { toast.Close(); });
        });
    }
    
    public static async Task ShowSuccess(string message, int timeToCloseInSeconds = 8)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            ToastBuilder builder = new ToastBuilder()
                .SetMessage(message)
                .SetModalBehavior(false)
                .SetBackgroundColor(Color.FromHex("#258750"));

            ToastPopup toast = builder.Build();

            await PopupNavigation.Instance.PushAsync(toast);

            await Task.Delay(timeToCloseInSeconds * 1000)
                .ContinueWith(_ => { toast.Close(); });
        });
    }
    
    public static async Task ShowError(string message, int timeToCloseInSeconds = 8)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            ToastBuilder builder = new ToastBuilder()
                .SetMessage(message)
                .SetModalBehavior(false)
                .SetBackgroundColor(Color.FromHex("#D83A52"));

            ToastPopup toast = builder.Build();

            await PopupNavigation.Instance.PushAsync(toast);

            await Task.Delay(timeToCloseInSeconds * 1000)
                .ContinueWith(_ => { toast.Close(); });
        });
    }
    
    public static async Task ShowWarning(string message, int timeToCloseInSeconds = 8)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            ToastBuilder builder = new ToastBuilder()
                .SetMessage(message)
                .SetModalBehavior(false)
                .SetBackgroundColor(Color.FromHex("#FDB022"));

            ToastPopup toast = builder.Build();

            await PopupNavigation.Instance.PushAsync(toast);

            await Task.Delay(timeToCloseInSeconds * 1000)
                .ContinueWith(_ => { toast.Close(); });
        });
    }

    public static async Task ShowGeneral(string message, int timeToCloseInSeconds = 4)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            ToastBuilder builder = new ToastBuilder()
                .SetMessage(message)
                .SetModalBehavior(false)
                .SetBackgroundColor(Color.FromHex("#323338"));

            ToastPopup toast = builder.Build();

            await PopupNavigation.Instance.PushAsync(toast);

            await Task.Delay(timeToCloseInSeconds * 1000)
                .ContinueWith(_ => { toast.Close(); });
        });
    }
}