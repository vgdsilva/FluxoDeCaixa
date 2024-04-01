using System.ComponentModel.Design.Serialization;

namespace FluxoDeCaixa.Controls;

public partial class WidgetView : ContentView
{
    public string Title
    {
        get { return (string) GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(WidgetView), defaultValue: "", propertyChanged: TitlePropertyChanged);

    static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var View = (WidgetView) bindable;
        View.labelTitle.Text = newValue.ToString();
    }
    
    public bool SeeMoreButtonIsVisible
    {
        get { return (bool) GetValue(SeeMoreButtonIsVisibleProperty); }
        set { SetValue(SeeMoreButtonIsVisibleProperty, value); }
    }

    public static readonly BindableProperty SeeMoreButtonIsVisibleProperty =
        BindableProperty.Create(nameof(SeeMoreButtonIsVisible), typeof(bool), typeof(WidgetView), defaultValue: false, propertyChanged: SeeMoreButtonIsVisiblePropertyChanged);

    static void SeeMoreButtonIsVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ( newValue == null )
            return;

        var View = (WidgetView) bindable;
        View.SeeMoreStack.IsVisible = (bool)newValue;
    }


    private View _widgetContent;
    public virtual View WidgetContent
    {
        get { return _widgetContent; }
        set
        {
            _widgetContent = value;
            ContentStack.Children.Add(value);
            OnPropertyChanged();
        }
    }

    private bool _isLoading = true;
    public bool IsLoading
    {
        get
        {
            return _isLoading;
        }
        set
        {
            _isLoading = value;
            this.LoadingStack.IsVisible = _isLoading;
            this.ContentStack.IsVisible = !_isLoading;
        }
    }

    public WidgetView()
	{
		InitializeComponent();
	}

    public virtual async void OnWidgetStart()
    {
        await ( BindingContext as BaseViewModel )?.OnWidgetStart();
        this.IsLoading = false;
    }
}