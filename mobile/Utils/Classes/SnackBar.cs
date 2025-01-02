namespace FluxoDeCaixa.MAUI.Utils.Classes;

public class SnackBar
{
    public static async Task ShowSuccess(string message, int timeToCloseInSeconds = 4)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        SnackBarBuilder builder = new SnackBarBuilder()
            .SetMessage(message)
            .SetBackgroundColor(Color.FromArgb("#5BAF00"))
            .SetTextColor(Colors.White)
            .SetDuration(TimeSpan.FromSeconds(timeToCloseInSeconds))
            .SetActionButtonText("Ok");

        var sanckBarMessage = builder.Build();
        await sanckBarMessage.Show(cancellationTokenSource.Token);
    }

    public static async Task ShowError(string message, int timeToCloseInSeconds = 4)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        await new SnackBarBuilder()
            .SetMessage(message)
            .SetBackgroundColor(Color.FromArgb("#EF4444"))
            .SetTextColor(Colors.White)
            .SetDuration(TimeSpan.FromSeconds(timeToCloseInSeconds))
            .SetActionButtonText("Ok")
            .SetActionButtonTextColor(Colors.White)
            .Show(cancellationTokenSource.Token);
    }

    public static async Task ShowWarning(string message, int timeToCloseInSeconds = 4)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        await new SnackBarBuilder()
            .SetMessage(message)
            .SetBackgroundColor(Color.FromArgb("#FFB500"))
            .SetTextColor(Colors.White)
            .SetDuration(TimeSpan.FromSeconds(timeToCloseInSeconds))
            .Show(cancellationTokenSource.Token);
    }

    public static async Task ShowInformation(string message, int timeToCloseInSeconds = 4)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        await new SnackBarBuilder()
            .SetMessage(message)
            .SetBackgroundColor(Color.FromArgb("#4B5563"))
            .SetTextColor(Colors.White)
            .SetDuration(TimeSpan.FromSeconds(timeToCloseInSeconds))
            .Show(cancellationTokenSource.Token);
    }
}
