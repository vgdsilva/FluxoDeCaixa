namespace FluxoDeCaixa.Controls;

public partial class EmptyView : ContentView
{

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(EmptyView), defaultValue: "");

    public string Text
    {
        get => (string) GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public EmptyView()
	{
		InitializeComponent();
	}
}