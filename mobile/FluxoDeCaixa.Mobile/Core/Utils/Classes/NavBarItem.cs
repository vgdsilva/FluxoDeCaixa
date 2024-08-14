using CommunityToolkit.Mvvm.Input;

namespace FluxoDeCaixa.Mobile.Core.Utils.Classes;

public class NavBarItem
{
    public ImageSource IconImageSource { get; set; }
    public IRelayCommand Command { get; set; }
}
