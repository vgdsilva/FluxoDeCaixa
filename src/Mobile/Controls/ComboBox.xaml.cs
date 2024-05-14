using FluxoDeCaixa.Core.Utils.Enums;
using FluxoDeCaixa.Core.Utils.Interfaces;

namespace FluxoDeCaixa.Controls;

public partial class ComboBox : ContentView, IEditController
{

    #region LabelText

    public static BindableProperty LabelTextProperty = BindableProperty.Create(
        propertyName: nameof(LabelText),
        returnType: typeof(string),
        declaringType: typeof(TextEdit),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: OnLabelTextValueChanged);

    public string LabelText
    {
        get => (string) GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    static void OnLabelTextValueChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ( bindable == null )
            return;

        ComboBox? view = bindable as ComboBox;

        if ( string.IsNullOrEmpty(newValue.ToString()) )
        {
            view.LabelTextStackLayout.IsVisible = false;
        }
        else
        {
            view.LabelTextStackLayout.IsVisible = true;
        }
    }

    public static BindableProperty LabelTextColorProperty = BindableProperty.Create(
        propertyName: nameof(LabelTextColor),
        returnType: typeof(Color),
        declaringType: typeof(TextEdit),
        defaultValue: Colors.Black,
        defaultBindingMode: BindingMode.TwoWay);

    public Color LabelTextColor
    {
        get => (Color) GetValue(LabelTextColorProperty);
        set => SetValue(LabelTextColorProperty, value);
    }

    public static BindableProperty LabelTextSizeProperty = BindableProperty.Create(
        propertyName: nameof(LabelTextSize),
        returnType: typeof(double),
        declaringType: typeof(TextEdit),
        defaultValue: (double) 14,
        defaultBindingMode: BindingMode.TwoWay);

    public double LabelTextSize
    {
        get => (double) GetValue(LabelTextSizeProperty);
        set => SetValue(LabelTextSizeProperty, value);
    }

    #endregion LabelText

    #region Frame

    public static BindableProperty BorderColorProperty = BindableProperty.Create(
        propertyName: nameof(BorderColor),
        returnType: typeof(Color),
        declaringType: typeof(TextEdit),
        defaultValue: Color.FromHex("#DCDCE4"),
        defaultBindingMode: BindingMode.TwoWay);

    public Color BorderColor
    {
        get => (Color) GetValue(BorderColorProperty);
        set { SetValue(BorderColorProperty, value); }
    }

    #endregion Frame

    #region Text/Placeholder

    public static BindableProperty PlaceholderTextProperty = BindableProperty.Create(
        propertyName: nameof(PlaceholderText),
        returnType: typeof(string),
        declaringType: typeof(TextEdit),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);

    public string PlaceholderText
    {
        get => (string) GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextColorProperty, value);
    }

    public static BindableProperty PlaceholderTextColorProperty = BindableProperty.Create(
        propertyName: nameof(PlaceholderTextColor),
        returnType: typeof(Color),
        declaringType: typeof(TextEdit),
        defaultValue: Color.FromHex("#8E8EA9"),
        defaultBindingMode: BindingMode.TwoWay);

    public Color PlaceholderTextColor
    {
        get => (Color) GetValue(LabelTextColorProperty);
        set => SetValue(LabelTextColorProperty, value);
    }

    public static BindableProperty TextSizeProperty = BindableProperty.Create(
        propertyName: nameof(TextSize),
        returnType: typeof(double),
        declaringType: typeof(TextEdit),
        defaultValue: (double) 14,
        defaultBindingMode: BindingMode.TwoWay);

    public double TextSize
    {
        get => (double) GetValue(TextSizeProperty);
        set => SetValue(TextSizeProperty, value);
    }


    public static BindableProperty TextColorProperty = BindableProperty.Create(
        propertyName: nameof(TextColor),
        returnType: typeof(Color),
        declaringType: typeof(TextEdit),
        defaultValue: Color.FromHex("#666687"),
        defaultBindingMode: BindingMode.TwoWay);

    public Color TextColor
    {
        get => (Color) GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    #endregion Text/Placeholder


    public static BindableProperty DropDownShowModeProperty = BindableProperty.Create(
        propertyName: nameof(DropDownShowMode),
        returnType: typeof(DropDownShowModeEnum),
        declaringType: typeof(ComboBox),
        defaultValue: DropDownShowModeEnum.Popup,
        defaultBindingMode: BindingMode.TwoWay);

    public DropDownShowModeEnum DropDownShowMode 
    { 
        get => (DropDownShowModeEnum) GetValue(DropDownShowModeProperty); 
        set => SetValue(DropDownShowModeProperty, value); 
    }

    public static BindableProperty DropDownIconProperty = BindableProperty.Create(
        propertyName: nameof(DropDownIcon),
        returnType: typeof(ImageSource),
        declaringType: typeof(ComboBox),
        //defaultValue: ImageSource.FromResource("icon_drop_down"),
        defaultBindingMode: BindingMode.TwoWay);

    public ImageSource DropDownIcon 
    {
        get => (ImageSource)GetValue(DropDownIconProperty); 
        set => SetValue(DropDownIconProperty, value); 
    }

    public static BindableProperty DropUpIconProperty = BindableProperty.Create(
        propertyName: nameof(DropUpIcon),
        returnType: typeof(ImageSource),
        declaringType: typeof(ComboBox),
        //defaultValue: ImageSource.FromResource("icon_drop_up"),
        defaultBindingMode: BindingMode.TwoWay);

    public ImageSource DropUpIcon
    {
        get => (ImageSource) GetValue(DropDownIconProperty);
        set => SetValue(DropDownIconProperty, value);
    }


    static BindableProperty ImageIconChevronProperty = BindableProperty.Create(
        propertyName: nameof(ImageIconChevron),
        returnType: typeof(ImageSource),
        declaringType: typeof(ComboBox),
        defaultValue: DropDownIconProperty,
        defaultBindingMode: BindingMode.TwoWay);

    private ImageSource ImageIconChevron
    {
        get;
        set;
    }

    public ComboBox()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}