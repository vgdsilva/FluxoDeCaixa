namespace FluxoDeCaixa.Controls;

public class FontAwesomeLabel : Label
{
    public FontAwesomeLabel()
    {
        Populate();
        this.Style = (Style)ResourcesUtils.GetResourceValue("FontAwesomeLabel");
    }

    public bool UseSolidFont
    {
        get { return (bool) GetValue(UseSolidFontProperty); }
        set { SetValue(UseSolidFontProperty, value); }
    }

    public static readonly BindableProperty UseSolidFontProperty =
        BindableProperty.Create(nameof(UseSolidFont), typeof(bool), typeof(FontAwesomeLabel), defaultValue: true, propertyChanged: OnUseSolidFontPropertyChanged);

    private static void OnUseSolidFontPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((FontAwesomeLabel) bindable).Populate();
    }

    void Populate()
    {
        this.FontFamily = UseSolidFont ? "FontAwesomeSolid" : "FontAwesomeRegular";
    }

}