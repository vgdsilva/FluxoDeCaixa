using DevExpress.Maui.Editors;
using System.Runtime.CompilerServices;

namespace FluxoDeCaixa.Controls;

public class FCComboBoxEdit : ComboBoxEdit
{

    public FCComboBoxEdit()
    {
        this.Tap += FCComboBoxEdit_Tap;    
    }

    private void FCComboBoxEdit_Tap(object? sender, System.ComponentModel.HandledEventArgs e)
    {
        ExecuteCommand(SearchTextChangedCommand, string.Empty);
    }

    public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(
        nameof(IsRequired), 
        typeof(bool), 
        typeof(FCComboBoxEdit), 
        false,
        BindingMode.TwoWay);

    public bool IsRequired
    {
        get { return (bool) GetValue(IsRequiredProperty); }
        set { SetValue(IsRequiredProperty, value); }
    }



    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if ( propertyName == nameof(LabelText) || propertyName == nameof(IsRequired) )
        {
            if ( !LabelText.IsNullOrEmpty() && !LabelText.EndsWith(" *") && IsRequired )
                LabelText += " *";

            return;
        }
    }
}
