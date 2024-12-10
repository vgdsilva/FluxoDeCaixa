using Microsoft.Maui.Controls.PlatformConfiguration;

namespace SistemaFluxodeCaixa.Views.Pages.Starter;

public partial class StarterPage : ContentPage
{
	public StarterPage()
	{
		InitializeComponent();
	}

    public override Window GetParentWindow()
    {
		var window = base.GetParentWindow();

		

		const int newWidth = 800;
        const int newHeight = 600;
        
        window.MinimumWidth = newWidth;
		window.Height = newHeight;
		window.MaximumHeight = newHeight;
        window.MinimumHeight = newHeight;
		window.Width = newWidth;
		window.MaximumWidth = newWidth;

        return window;
    }
}