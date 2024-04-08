using FluxoDeCaixa.Domain.Enums;

namespace FluxoDeCaixa.Controls;

public class FontAwesomeLabel : Label
{
    public static readonly BindableProperty IconProperty =
               BindableProperty.Create(nameof(Icon), typeof(FontAwesomeSolidIconEnum), typeof(FontAwesomeLabel), null, propertyChanged: OnIconPropertyChanged);

    public FontAwesomeSolidIconEnum Icon
    {
        get => (FontAwesomeSolidIconEnum) GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }


    public FontAwesomeLabel()
    {
        FontFamily = "FontAwesomeSolid";
    }


    // Método chamado sempre que a propriedade Icon é alterada
    private static void OnIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ( newValue == null )
            return;

        var label = (FontAwesomeLabel) bindable;

        if ( newValue is FontAwesomeSolidIconEnum Enum )
            label.Text = Enum.GetEnumDescription();
    }
}