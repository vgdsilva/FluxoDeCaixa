
namespace FluxoDeCaixa.Mobile.Controls;

public class DatePickerLabel : ContentView
{
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


    public DatePickerLabel()
	{
		_label = new Label
		{
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			GestureRecognizers = { new TapGestureRecognizer { Command = new Command(OnLabelTapped) } }
		};

		_datePicker = new DatePicker
		{
			IsVisible = false,
		};

        _datePicker.DateSelected += OnDatePickerDateSelected;

		Content = new StackLayout
		{
			Children = { _label, _datePicker }
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
        //_datePicker.IsVisible = !_datePicker.IsVisible;
    }

    void OnDatePickerDateSelected(object? sender, DateChangedEventArgs e)
	{
		SelectedDate = e.NewDate;
	}

    void UpdateLabel()
    {
        _label.Text = SelectedDate.ToString(DateFormat);
    }
}