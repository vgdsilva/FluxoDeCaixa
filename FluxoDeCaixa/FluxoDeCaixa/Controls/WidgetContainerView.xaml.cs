namespace FluxoDeCaixa.Controls;

public partial class WidgetContainerView : StackLayout
{

    public static BindableProperty WidgetsProperty =
           BindableProperty.Create(nameof(Widgets), typeof(List<WidgetView>), typeof(WidgetContainerView), propertyChanged: OnWidgetsPropertyChanged);

    public List<WidgetView> Widgets
    {
        get => (List<WidgetView>) GetValue(WidgetsProperty);
        set => SetValue(WidgetsProperty, value);
    }

    static void OnWidgetsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ( newValue == oldValue )
            return;

        if ( newValue == null )
            return;

        if ( newValue is List<WidgetView> widgets )
        {
            var view = (WidgetContainerView) bindable;
            foreach ( var item in widgets )
            {
                view.WidgetContainerStack.Children.Add(item);
                item.OnWidgetStart();
            }
        }
    }

    public WidgetContainerView()
	{
		InitializeComponent();
	}
}