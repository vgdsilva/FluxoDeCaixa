using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FluxoDeCaixa.Mobile.Views.Pages;

public class BasePages : ContentPage
{
    public static readonly BindableProperty BackButtonCommandProperty = BindableProperty.Create(nameof(BackButtonCommand), typeof(ICommand), typeof(BasePages), propertyChanged: OnBackButtonCommandPropertyChanged);
    public new static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(BasePages), defaultValue: "", propertyChanged: OnTitlePropertyChanged);

    private Label labelTitle;

    public ICommand BackButtonCommand
    {
        get { return (ICommand) GetValue(BackButtonCommandProperty); }
        set { SetValue(BackButtonCommandProperty, value); }
    }

    public new string Title
    {
        get => (string) GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    private static void OnBackButtonCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        //BasePages page = (BasePages) bindable;
        //page.backButtonBehavior.Command = (ICommand) newValue;
    }

    private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if ( newValue == oldValue )
            return;

        string title = (string) newValue ?? string.Empty;

        BasePages page = (BasePages) bindable;
        page.labelTitle.Text = title;
        if ( string.IsNullOrEmpty(page.labelTitle.AutomationId) )
        {
            page.labelTitle.AutomationId = "AIDCBasePagesNavigationBarTitulo";
        }
    }


    public BasePages()
	{
        ChildAdded += BasePages_ChildAdded;
        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SetNavigationBar();
    }

    private void BasePages_ChildAdded(object? sender, ElementEventArgs e)
    {

        Microsoft.Maui.Controls.Layout layout = (Microsoft.Maui.Controls.Layout) e.Element;

        var layoutChildrenList = layout.Children.ToList();
        layout.Children.Clear();

        var mainGrid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Star },
            }
        };

        var navbar = CreateCustomNavigationBar();
        Grid.SetRow(navbar, 0);
        mainGrid.Children.Add(navbar);

        int count = 0;
        Grid mainContent = new Grid();
        foreach ( View item in layoutChildrenList )
        {
            Grid.SetRow(item, count);
            mainContent.Children.Add(item);
            count++;
        }
        Grid.SetRow(mainContent, 1);
        mainGrid.Children.Add(mainContent);

        layout.Children.Add(mainGrid);
    }

    View CreateCustomNavigationBar()
    {
        Grid customNavigationBar = new Grid
        {
            Padding = 16,
            BackgroundColor = Colors.White,
            ColumnSpacing = 10,
            ColumnDefinitions =
            {
                new ColumnDefinition{ Width = GridLength.Auto },
                new ColumnDefinition{ Width = GridLength.Star },
                new ColumnDefinition{ Width = GridLength.Auto },
            }
        };

        ImageButton backButton = new ImageButton
        {
            Source = "arrow_back.png",
            MaximumHeightRequest = 20,
            MaximumWidthRequest = 20,
        };
        backButton.SetBinding(ImageButton.CommandProperty, new Binding("BackButtonCommand"));

        HorizontalStackLayout toolbarStack = new HorizontalStackLayout
        {
            HorizontalOptions = LayoutOptions.End,
            Spacing = 6,
        };

        Grid.SetColumn(backButton, 0);
        customNavigationBar.Children.Add(backButton);

        labelTitle = CreateTitle();
        Grid.SetColumn(labelTitle, 1);
        customNavigationBar.Children.Add(labelTitle);

        Grid.SetColumn(toolbarStack, 2);
        customNavigationBar.Children.Add(toolbarStack);


        return customNavigationBar;
    }

    Label CreateTitle()
    {
        Label title = new Label();
        title.Text = Title;
        title.FontSize = 18;

        return title;
    }

    void SetNavigationBar()
    {
        Shell.SetNavBarIsVisible(this, false);

        NavigationPage.SetHasNavigationBar(this, false);
    }
}