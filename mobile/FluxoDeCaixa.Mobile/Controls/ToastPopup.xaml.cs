using RGPopup.Maui.Pages;
using RGPopup.Maui.Services;

namespace FluxoDeCaixa.Mobile.Controls;

public partial class ToastPopup : PopupPage
{
    private bool Closed;
    private bool _modalBehavior;

    public ToastPopup(string message, bool modalBehavior = false)
	{
        _modalBehavior = modalBehavior;

		InitializeComponent();

        Message.Text = message;

        if (_modalBehavior)
        {
            var conteudo = Content;

            var layout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(-20),
                BackgroundColor = Colors.Transparent
            };

            layout.Children.Add(conteudo);

            Content = layout;
        }
    }

    public void SetBackgroundColor(Color backgroundColor) => this.Container.BackgroundColor = backgroundColor;

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        Closed = true;
    }

    protected override bool OnBackButtonPressed()
    {
        if (_modalBehavior)
        {
            return true;
        }

        return base.OnBackButtonPressed();
    }

    public async void Close()
    {
        if (Closed)
            return;
        await PopupNavigation.Instance.RemovePageAsync(this);
    }
}