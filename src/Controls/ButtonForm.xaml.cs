using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FluxoDeCaixa.Mobile.Controls;

public partial class ButtonForm : Frame
{
    public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ButtonForm));

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ButtonForm), defaultValue: default(string));

    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(string), typeof(ButtonForm), defaultBindingMode: BindingMode.TwoWay, defaultValue: default(string), propertyChanged: IconPropertyChanged);

    public static readonly BindableProperty IsIconVisibleProperty =
        BindableProperty.Create(nameof(IsIconVisible), typeof(bool), typeof(ButtonForm), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public static readonly BindableProperty BackgroundColorChargerProperty =
        BindableProperty.Create(nameof(BackgroundColorCharger), typeof(Color), typeof(ButtonForm), Color.FromHex(""));

    public static readonly BindableProperty PressedBackgroundColorProperty =
        BindableProperty.Create(nameof(PressedBackgroundColor), typeof(Color), typeof(ButtonForm), Color.FromHex(""));

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ButtonForm), Color.FromHex(""));

    public static readonly BindableProperty IconColorProperty =
        BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(ButtonForm), Color.FromHex(""));

    public static readonly BindableProperty StyleChargerProperty =
        BindableProperty.Create(nameof(StyleCharger), typeof(Style), typeof(ButtonForm));

    public static readonly BindableProperty DisabledBackgroundColorProperty =
        BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(ButtonForm), Color.FromHex("#E5E7EB"));

    public static readonly BindableProperty DisabledBorderColorProperty =
        BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(ButtonForm), Color.FromHex("#E5E7EB"));

    public static readonly BindableProperty DisabledTextColorProperty =
        BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(ButtonForm), Color.FromHex("#9CA3AF"));

    public Color DisabledBackgroundColor
    {
        get => (Color) GetValue(DisabledBackgroundColorProperty);
        set => SetValue(DisabledBackgroundColorProperty, value);
    }

    public Color DisabledBorderColor
    {
        get => (Color) GetValue(DisabledBorderColorProperty);
        set => SetValue(DisabledBorderColorProperty, value);
    }

    public Color DisabledTextColor
    {
        get => (Color) GetValue(DisabledTextColorProperty);
        set => SetValue(DisabledTextColorProperty, value);
    }

    Style StyleCharger
    {
        get => (Style) GetValue(StyleChargerProperty);
        set => SetValue(StyleChargerProperty, value);
    }

    public ICommand Command
    {
        get => (ICommand) GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public string Text
    {
        get => (string) GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Icon
    {
        get => (string) GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    bool IsIconVisible
    {
        get => (bool) GetValue(IsIconVisibleProperty);
        set => SetValue(IsIconVisibleProperty, value);
    }

    public Color BackgroundColorCharger
    {
        get => (Color) GetValue(BackgroundColorChargerProperty);
        set => SetValue(BackgroundColorChargerProperty, value);
    }

    public Color PressedBackgroundColor
    {
        get => (Color) GetValue(PressedBackgroundColorProperty);
        set => SetValue(PressedBackgroundColorProperty, value);
    }

    public Color TextColor
    {
        get => (Color) GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public Color IconColor
    {
        get => (Color) GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public ButtonForm()
	{
		InitializeComponent();
        StyleCharger = Style;
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        TappedEventArgs tappedEvgs = e as TappedEventArgs;
        object data = tappedEvgs.Parameter;

        if ( !IsEnabled )
            return;

        if ( PressedBackgroundColor != null )
            BackgroundColor = PressedBackgroundColor;

        if ( Command?.CanExecute(data) ?? false )
            Command?.Execute(data);

        Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
        {
            BackgroundColor = BackgroundColorCharger;
            return false;
        });
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if ( propertyName.Equals(IconProperty.PropertyName) )
        {
            if ( string.IsNullOrEmpty(Icon) )
                IsIconVisible = false;
            else
                IsIconVisible = true;
        }

        if ( propertyName.Equals(StyleProperty) )
            StyleCharger = Style;
    }

    static void IconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ButtonForm control = bindable as ButtonForm;

        if ( string.IsNullOrEmpty((string) newValue) )
        {
            control.IsIconVisible = false;
        }
        else
        {
            control.IsIconVisible = true;
        }
    }
}