using FluxoDeCaixa.Mobile.Core.Utils.Extensions;
using FluxoDeCaixa.Mobile.ViewModels;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FluxoDeCaixa.Mobile.Views.Pages;

public class BasePages : ContentPage
{
    private Label _labelTitle;
    private ImageButton backButton;
    private View _titleView;
    
    public static readonly BindableProperty BackButtonCommandProperty = 
        BindableProperty.Create(
            nameof(BackButtonCommand), 
            typeof(ICommand), 
            typeof(BasePages));

    public new static readonly BindableProperty TitleProperty = 
        BindableProperty.Create(
            nameof(Title), 
            typeof(string), 
            typeof(BasePages), 
            defaultValue: "");

    public static readonly BindableProperty TitleViewProperty =
        BindableProperty.Create(
            nameof(TitleView),
            typeof(View),
            typeof(BasePages));

    public static readonly BindableProperty HasNavigationBarProperty =
        BindableProperty.Create(
            nameof(HasNavigationBar),
            typeof(bool),
            typeof(BasePages),
            defaultValue: true,
            defaultBindingMode: BindingMode.TwoWay);

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

    public View TitleView
    {
        get => (View) GetValue(TitleViewProperty);
        set => SetValue(TitleViewProperty, value);
    }

    public bool HasNavigationBar 
    { 
        get => (bool) GetValue(HasNavigationBarProperty);
        set => SetValue(HasNavigationBarProperty, value); 
    }


    public BasePages()
	{
        ChildAdded += BasePages_CreatePage;  
        
        On<iOS>().SetUseSafeArea(true);
        HideSoftInputOnTapped = true;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as BaseViewModel)?.Page_Load();

        SetNavigationBar();
    }

    private void BasePages_CreatePage(object? sender, ElementEventArgs e)
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

        if ( HasNavigationBar )
        {
            var navbar = CreateCustomNavigationBar();
            Grid.SetRow(navbar, 0);
            mainGrid.Children.Add(navbar);
        }

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
            Padding = 24,
            BackgroundColor = Colors.White,
            ColumnSpacing = 10,
            ColumnDefinitions =
            {
                new ColumnDefinition{ Width = GridLength.Auto },
                new ColumnDefinition{ Width = GridLength.Star },
                new ColumnDefinition{ Width = GridLength.Auto },
            }
        };

        if (App.Current.MainPage != this )
        {
            backButton = CreateBackButton();
            Grid.SetColumn(backButton, 0);
            customNavigationBar.Children.Add(backButton);
        }

        if (TitleView is not null )
        {
            _titleView = TitleView;
            Grid.SetColumn(_titleView, 1);
            customNavigationBar.Children.Add(_titleView);
        }
        else
        {
            _labelTitle = CreateTitle();
            Grid.SetColumn(_labelTitle, 1);
            customNavigationBar.Children.Add(_labelTitle);
        }


        return customNavigationBar;
    }

    ImageButton CreateBackButton()
    {
        var imageButton = new ImageButton();
        imageButton.Style = (Style) ResourceUtils.GetResourceValue("CustomNavigationBarBackButton");
        imageButton.SetBinding(ImageButton.CommandProperty, new Binding("BackButtonCommand"));

        return imageButton;
    }

    Label CreateTitle()
    {
        Label title = new Label();
        title.Text = Title;
        title.Style = (Style) ResourceUtils.GetResourceValue("CustomNavigationBarTitle");
        return title;
    }

    void SetNavigationBar()
    {
        Shell.SetNavBarIsVisible(this, false);
        Microsoft.Maui.Controls.NavigationPage.SetHasNavigationBar(this, false);
    }
}