namespace FluxoDeCaixa.Mobile.Controls;

public class FontAwesomeLabel : Label
{

    public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(FontAwesomeLabel), string.Empty, propertyChanged: OnIconPropertyChanged);

    public string Icon
    {
        get => (string) GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }


    public FontAwesomeLabel()
	{
		FontFamily = "FontAwesomeSolid";
	}

    // Método chamado sempre que a propriedade Icon é alterada
    private static void OnIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var label = (FontAwesomeLabel) bindable;
        label.Text = (string) newValue; // Atualiza o valor da propriedade Text com o valor do ícone
    }
}