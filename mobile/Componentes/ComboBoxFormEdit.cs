using DevExpress.Maui.Editors;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FluxoDeCaixa.MAUI.Componentes;

public class ComboBoxFormEdit : ComboBoxEdit
{

    public ComboBoxFormEdit()
    {
        NoResultsFoundText = "Nenhum registro encontrado";
        ItemsSource = Enumerable.Empty<object>();

        this.Tap += ComboBoxFormEdit_Tap;
    }

    private void ComboBoxFormEdit_Tap(object? sender, System.ComponentModel.HandledEventArgs e)
    {
        if (FilterTextChangedCommand?.CanExecute(null) ?? false)
            FilterTextChangedCommand?.Execute(string.Empty);
    }

    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(ComboBoxFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public bool IsRequired
    {
        get { return (bool)GetValue(IsRequiredProperty); }
        set { SetValue(IsRequiredProperty, value); }
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(IsDropDownOpen))
        {
            if (IsDropDownOpen)
            {
               if (FilterTextChangedCommand?.CanExecute(null) ?? false)
                    FilterTextChangedCommand?.Execute(string.Empty);
            }
            return;
        }

        if (propertyName == nameof(LabelText) || propertyName == nameof(IsRequired))
        {
            if (!LabelText.IsNullOrEmpty() && !LabelText.EndsWith(" *") && IsRequired)
                LabelText += " *";
            return;
        }
    }
}
