namespace FluxoDeCaixa.Mobile.Controls;

public partial class TextInput : Grid
{

    public static readonly BindableProperty PlaceholderTextProperty =
        BindableProperty.Create(
            propertyName: nameof(PlaceholderText),
            returnType: typeof(string),
            declaringType: typeof(PickerInput),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay);

    public string PlaceholderText
    {
        get => (string) GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }


    public static readonly BindableProperty LabelTextProperty =
        BindableProperty.Create(
            propertyName: nameof(LabelText),
            returnType: typeof(string),
            declaringType: typeof(PickerInput),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnLabelTextPropertyChanged);

    public string LabelText
    {
        get => (string) GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    static void OnLabelTextPropertyChanged (BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is null)
            return;

        TextInput input = bindable as TextInput;

        if (string.IsNullOrEmpty(newValue.ToString()))
            input.LabelTextField.IsVisible = false;

        input.LabelTextField.IsVisible = true;
    }


    public TextInput()
	{
		InitializeComponent();
	}
}