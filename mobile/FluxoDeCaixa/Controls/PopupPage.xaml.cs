using CommunityToolkit.Maui.Views;

namespace FluxoDeCaixa.Controls;

public partial class PopupPage : Popup
{

    PopupShowOptions _menuOption = PopupShowOptions.BottomBar;


    public static readonly BindableProperty TituloProperty = BindableProperty.Create(nameof(TituloProperty), typeof(string), typeof(PopupPage));

    public string Titulo
    {
        get { return (string) GetValue(TituloProperty); }
        set { SetValue(TituloProperty, value); }
    }


    public PopupPage()
	{
		InitializeComponent();

        this.ChildAdded += PopupPage_ChildAdded;

    }

    void PopupPage_ChildAdded(object? sender, ElementEventArgs e)
    {
        if ( e.Element is not Layout )
            return;

        StackLayout layout = (StackLayout) e.Element;
        layout.Style = GetPopupStyle();

        var layoutChildrenList = layout.Children.ToList();

        if ( !string.IsNullOrEmpty(Titulo) )
        {
            layout.Children.Clear();
            layout.Children.Add(CreateTitle());
        }

        foreach ( var comp in layoutChildrenList )
        {
            layout.Children.Add(comp);
        }
    }

    Style GetPopupStyle()
    {
        switch ( _menuOption )
        {
            case PopupShowOptions.LeftBar:
                return (Style) ResoucesExtensions.GetResourceValue(PopupStyle.LEFT_BAR);
            case PopupShowOptions.BottomBar:
                return (Style) ResoucesExtensions.GetResourceValue(PopupStyle.BOTTOM_BAR);
            case PopupShowOptions.BottomFloat:
                return (Style) ResoucesExtensions.GetResourceValue(PopupStyle.BOTTOM_FLOAT);
            case PopupShowOptions.CenterFloat:
                return (Style) ResoucesExtensions.GetResourceValue(PopupStyle.CENTER_FLOAT);
            case PopupShowOptions.RightBar:
            default:
                return (Style) ResoucesExtensions.GetResourceValue(PopupStyle.RIGHT_BAR);

        }
    }

    static StackLayout CreateTitle(string Titulo = null)
    {
        var stackLayout = new StackLayout();
        stackLayout.Orientation = StackOrientation.Horizontal;
        stackLayout.HorizontalOptions = LayoutOptions.Fill;

        Label titulo = new Label();
        titulo.Style = (Style) ResoucesExtensions.GetResourceValue(LabelStyle.LABEL_TITULO);
        titulo.Text = Titulo;

        stackLayout.Children.Add(titulo);

        return stackLayout;
    }

    public void SetTipoMenu(PopupShowOptions Opcao)
    {
        switch ( Opcao )
        {
            case PopupShowOptions.BottomFloat:
                Popup.HorizontalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Fill;
                Popup.VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.End;
                break;
            case PopupShowOptions.LeftBar:
                Popup.HorizontalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Start;
                Popup.VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Fill;
                break;
            case PopupShowOptions.BottomBar:
                Popup.HorizontalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Fill;
                Popup.VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.End;
                break;
            case PopupShowOptions.CenterFloat:
                Popup.HorizontalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Center;
                Popup.VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Center;
                break;
            case PopupShowOptions.RightBar:
            default:
                Popup.HorizontalOptions = Microsoft.Maui.Primitives.LayoutAlignment.End;
                Popup.VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.Fill;
                break;
        }
        _menuOption = Opcao;
    }

    public static class PopupStyle
    {
        public static string RIGHT_BAR = "PopupRightBar";
        public static string LEFT_BAR = "PopupLeftBar";
        public static string BOTTOM_BAR = "PopupBottomBar";
        public static string BOTTOM_FLOAT = "PopupBottomFloat";
        public static string CENTER_FLOAT = "PopupCenterFloat";
    }
    public static class LabelStyle
    {
        public static string LABEL_TITULO = "PopupLabelTituloStyle";
    }

    public enum PopupShowOptions
    {
        RightBar = 0,
        LeftBar = 1,
        BottomBar = 2,
        BottomFloat = 3,
        CenterFloat = 4
    }
}