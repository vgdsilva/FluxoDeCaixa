namespace FluxoDeCaixa.Views.Pages;

public partial class BasePages : ContentPage
{
    const string LAYOUT_STYLE = "StackLayoutNavigationBar";
    const string TITLE_STYLE = "TitleNavigationBar";

    #region Title

    Label labelTitle = new();

    public new static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(BasePages), defaultValue: "", propertyChanged: OnTitlePropertyChanged);

    public new string Title
    {
        get => (string) GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ( newValue == oldValue )
            return;

        string title = (string) newValue ?? string.Empty;

        BasePages page = (BasePages) bindable;
        page.labelTitle.Text = title;
    }

    #endregion

    private void CreateNavigationBarComponents()
    {
        //backButtonBehavior = Shell.GetBackButtonBehavior(this) ?? new BackButtonBehavior();

        StackLayout navigationBar = new StackLayout();
        navigationBar.Style = (Style) ResourcesUtils.GetResourceValue(LAYOUT_STYLE);

        labelTitle = new Label();
        labelTitle.Style = (Style) ResourcesUtils.GetResourceValue(TITLE_STYLE);

        navigationBar.Children.Add(labelTitle);

        Shell.SetTitleView(this, navigationBar);
    }
}