using FluxoDeCaixa.Controls;

namespace FluxoDeCaixa.ViewModels;

public partial class MainViewModel : BaseViewModel
{

    [ObservableProperty]
    List<WidgetView> widgets;

    public MainViewModel()
    {
        Widgets = new();
    }

    public override void OnAppearing()
    {
        base.OnAppearing();

        List<WidgetView> _widgets = new List<WidgetView>
        {
            new Views.Widgets.MyAccountsWidget(),
            new Views.Widgets.MyCardsWidget(),
        };

        Widgets = _widgets;
    }
}
