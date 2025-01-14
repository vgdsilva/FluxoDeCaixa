using FluxoDeCaixa.MAUI.Core.Utils.ResoucesExtencions;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FluxoDeCaixa.MAUI.Componentes;

public partial class ButtonForm : Border
{
    public static readonly BindableProperty DisabledBackgroundColorProperty = BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(ButtonForm), Color.FromArgb("#E5E7EB"));
    public Color DisabledBackgroundColor
    {
        get => (Color)GetValue(DisabledBackgroundColorProperty);
        set => SetValue(DisabledBackgroundColorProperty, value);
    }

    public static readonly BindableProperty DisabledBorderColorProperty = BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(ButtonForm), Color.FromArgb("#E5E7EB"));
    public Color DisabledBorderColor
    {
        get => (Color)GetValue(DisabledBorderColorProperty);
        set => SetValue(DisabledBorderColorProperty, value);
    }

    public static readonly BindableProperty DisabledTextColorProperty = BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(ButtonForm), Color.FromArgb("#9CA3AF"));
    public Color DisabledTextColor
    {
        get => (Color)GetValue(DisabledTextColorProperty);
        set => SetValue(DisabledTextColorProperty, value);
    }

    public static readonly BindableProperty StyleChargerProperty = BindableProperty.Create(nameof(StyleCharger), typeof(Style), typeof(ButtonForm));
    public Style StyleCharger
    {
        get => (Style)GetValue(StyleChargerProperty);
        set => SetValue(StyleChargerProperty, value);
    }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ButtonForm));
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ButtonForm));
    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ButtonForm), defaultValue: default(string));
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(ButtonForm), defaultBindingMode: BindingMode.TwoWay, defaultValue: default(string), propertyChanged: IconPropertyChanged);
    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    static void IconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ButtonForm control = bindable as ButtonForm;

        if (string.IsNullOrEmpty((string)newValue))
        {
            control.IsIconVisible = false;
        }
        else
        {
            control.IsIconVisible = true;
        }
    }

    public static readonly BindableProperty IsIconVisibleProperty = BindableProperty.Create(nameof(IsIconVisible), typeof(bool), typeof(ButtonForm), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);
    public bool IsIconVisible
    {
        get => (bool)GetValue(IsIconVisibleProperty);
        set => SetValue(IsIconVisibleProperty, value);
    }

    public static readonly BindableProperty BackgroundColorChargerProperty = BindableProperty.Create(nameof(BackgroundColorCharger), typeof(Color), typeof(ButtonForm), Color.FromArgb("#5BAF00"));
    public Color BackgroundColorCharger
    {
        get => (Color)GetValue(BackgroundColorChargerProperty);
        set => SetValue(BackgroundColorChargerProperty, value);
    }

    public static readonly BindableProperty PressedBackgroundColorProperty = BindableProperty.Create(nameof(PressedBackgroundColor), typeof(Color), typeof(ButtonForm), Color.FromArgb("#498B00"));
    public Color PressedBackgroundColor
    {
        get => (Color)GetValue(PressedBackgroundColorProperty);
        set => SetValue(PressedBackgroundColorProperty, value);
    }

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ButtonForm), Colors.White);
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(ButtonForm));
    public Color IconColor
    {
        get => (Color)GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }

    public ButtonForm()
	{
		InitializeComponent();
        StyleCharger = Style;
        BackgroundColorCharger = BackgroundColor;
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        if (!IsEnabled)
            return;

        TappedEventArgs? tappedEvgs = e as TappedEventArgs;
        object? parameter = tappedEvgs?.Parameter ?? CommandParameter;

        if (PressedBackgroundColor != null)
            BackgroundColor = PressedBackgroundColor;

        if (Command?.CanExecute(parameter) ?? false)
            Command?.Execute(parameter);

        Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
        {
            BackgroundColor = BackgroundColorCharger;
            return false;
        });
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (string.Equals(propertyName, nameof(IconProperty)))
            IsIconVisible = !string.IsNullOrEmpty(Icon);

        if (string.Equals(propertyName, nameof(StyleProperty.PropertyName)))
            StyleCharger = Style;
        
    }
}