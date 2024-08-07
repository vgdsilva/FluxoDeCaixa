using System.Windows.Input;

namespace FluxoDeCaixa.Mobile.Controls;

public partial class DatePicker : ContentView
{

    public static readonly BindableProperty DateFormatProperty =
        BindableProperty.Create(
            nameof(DateFormat),
            typeof(string),
            typeof(DatePicker),
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
            typeof(DatePicker),
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
            typeof(DatePicker));


    public ICommand SelectedDateCommand
    {
        get => (ICommand)GetValue(SelectedDateCommandProperty);
        set => SetValue(SelectedDateCommandProperty, value);
    }


    private Microsoft.Maui.Controls.DatePicker _datePicker;

    public DatePicker()
	{

        _datePicker = new Microsoft.Maui.Controls.DatePicker
        {
            IsVisible = false,
        };
        _datePicker.DateSelected += OnDatePickerDateSelected;
        pickerContent.Children.Add(_datePicker);

		InitializeComponent();
    }

    static void OnDateFormatChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (DatePicker)bindable;
        control.UpdateLabel();
    }

    static void OnSelectedDateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (DatePicker)bindable;
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

        dateLabel.Text = text;
    }
}