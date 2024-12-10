using Microsoft.Maui.Controls.PlatformConfiguration;

namespace SistemaFluxodeCaixa;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        Application.Current!.UserAppTheme = AppTheme.Light;

		MainPage = new Views.Pages.Starter.StarterPage();
	}

    protected override Window CreateWindow(IActivationState? activationState)
    {
		var window = base.CreateWindow(activationState);

		const double newWidth = 1600;
        const double newHeight = 600;
        
        window.MinimumWidth = newWidth;
        window.MinimumHeight = newHeight;

		// give it some time to complete window resizing task.
        // await window.Dispatcher.DispatchAsync(() => { });

        var disp = DeviceDisplay.Current.MainDisplayInfo;

        // move to screen center
        window.X = (disp.Width / disp.Density - window.Width) / 2;
        window.Y = (disp.Height / disp.Density - window.Height) / 2;

        return window;
    }
}
