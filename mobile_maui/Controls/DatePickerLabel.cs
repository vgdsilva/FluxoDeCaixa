
using Microsoft.Maui.Controls.Shapes;
using System.Windows.Input;

namespace FluxoDeCaixa.Mobile.Controls;

public class DatePickerLabel : ContentView
{
	private Border _border;
	private Label _label;
	private DatePicker _datePicker;

	public static readonly BindableProperty DateFormatProperty =
		BindableProperty.Create(
			nameof(DateFormat),
			typeof(string),
			typeof(DatePickerLabel),
			"dd/MM/yyyy",
			propertyChanged: OnDateFormatChanged);


	public string DateFormat
	{
		get => (string)GetValue(DateFormatProperty);
		set => SetValue(DateFormatProperty, value);
	}

	public static readonly BindableProperty SelectedDateProperty =
		BindableProperty.Create(
			nameof(SelectedDate),
			typeof(DateTime),
			typeof(DatePickerLabel),
			DateTime.Now,
			propertyChanged: OnSelectedDateChanged);


    public DateTime SelectedDate 
	{
		get => (DateTime)GetValue(SelectedDateProperty);
		set => SetValue(SelectedDateProperty, value); 
	}

    public static readonly BindableProperty SelectedDateCommandProperty =
        BindableProperty.Create(
            nameof(SelectedDateCommand),
            typeof(ICommand),
            typeof(DatePickerLabel));


    public ICommand SelectedDateCommand
	{
		get => (ICommand)GetValue(SelectedDateCommandProperty);
		set => SetValue(SelectedDateCommandProperty, value);
	}


    public DatePickerLabel()
	{
		_label = new Label
		{
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			GestureRecognizers = { new TapGestureRecognizer { Command = new Command(OnLabelTapped) } },
			FontSize = 16,
			TextColor = Colors.White
		};

		_datePicker = new DatePicker
		{
			IsVisible = false,
		};


        _border = new Border
        {
            Padding = new Thickness(24, 12),
            StrokeShape = new RoundRectangle()
            {
                CornerRadius = new CornerRadius(60)
            },
            BackgroundColor = Color.FromHex("#323238"),
            Content = new StackLayout
            {
                Children = { _label, _datePicker }
            }
        };

        Content = new StackLayout
		{
			Children = { _border }
		};

		UpdateLabel();
	}

    

    static void OnDateFormatChanged(BindableObject bindable, object oldValue, object newValue)
	{
		var control = (DatePickerLabel)bindable;
		control.UpdateLabel();
	}

	static void OnSelectedDateChanged(BindableObject bindable, object oldValue, object newValue)
	{
        var control = (DatePickerLabel)bindable;
        control.UpdateLabel();
    }

    void OnLabelTapped(object obj)
    {
		_datePicker.Focus();
    }

    void OnDatePickerDateSelected(object? sender, DateChangedEventArgs e)
	{
		SelectedDate = e.NewDate;

		if (SelectedDateCommand?.CanExecute(e) ?? false)
			SelectedDateCommand?.Execute(e);
			
	}

    void UpdateLabel()
    {
		var date = SelectedDate.ToString(DateFormat);
		string text = date;
		if (DateFormat.Equals("DDDD - yyyy"))
		{
			text = date.Replace("-", "de");
		}

		_label.Text = text;
    }
}