
using DevExpress.Maui.Editors;

namespace FluxoDeCaixa.MAUI.Componentes;

public class TextFormEdit : TextEdit
{
    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(TextFormEdit), false);
    public bool IsRequired
    {
        get { return (bool)GetValue(IsRequiredProperty); }
        set { SetValue(IsRequiredProperty, value); }
    }


    public TextFormEdit()
    {
        Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence);
        Keyboard = Keyboard.Chat;
    }
}
