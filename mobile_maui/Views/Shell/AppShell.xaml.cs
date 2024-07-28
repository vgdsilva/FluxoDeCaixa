using FluxoDeCaixa.Mobile.Views.Pages.Categoria;

namespace FluxoDeCaixa.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CategoriaPage), typeof(CategoriaPage));
    }
}
