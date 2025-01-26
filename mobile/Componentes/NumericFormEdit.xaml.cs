using DevExpress.Maui.Core;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace FluxoDeCaixa.MAUI.Componentes;

public partial class NumericFormEdit : StackLayout
{
    decimal? ValorAtual { get; set; }
    bool teveEntrada { get; set; }

    public NumericFormEdit()
	{
		InitializeComponent();
	}
    private static void ValuePorpertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        NumericFormEdit numeric = bindable as NumericFormEdit;

        if (newValue == null)
        {
            numeric.ValorAtual = numeric.AllowNullValue ? null : 0;

            if (!numeric.AllowNullValue)
            {
                if (numeric.OcultarPontoMilhar)
                    numeric.Entrada.Text = string.Format(ObtenhaMascara(numeric.CasasDecimais), numeric.ValorAtual).Replace(".", "");
                else
                    numeric.Entrada.Text = string.Format(ObtenhaMascara(numeric.CasasDecimais), numeric.ValorAtual);
            }
            else
            {
                numeric.Entrada.Text = null;
            }

            return;
        }

        decimal.TryParse($"{newValue}", out decimal valorPadrao);

        numeric.ValorAtual = valorPadrao;


        if (numeric.OcultarPontoMilhar)
            numeric.Entrada.Text = string.Format(ObtenhaMascara(numeric.CasasDecimais), numeric.ValorAtual).Replace(".", "");
        else
            numeric.Entrada.Text = string.Format(ObtenhaMascara(numeric.CasasDecimais), numeric.ValorAtual);
    }

    static string ObtenhaMascara(int numeroCasas)
    {
        if (numeroCasas <= 0)
        {
            return "{0:#,##0}";
        }

        StringBuilder mascaraComplementoBuilder = new StringBuilder(".");
        mascaraComplementoBuilder.Append('0', numeroCasas);

        return "{0:#,##0" + mascaraComplementoBuilder + "}";
    }

    private void Entrada_Focused(object sender, FocusEventArgs e)
    {
        teveEntrada = false;
        if (ValorAtual == null)
            Value = 0;

    }

    private void Entrada_Unfocused(object sender, FocusEventArgs e)
    {
        if (teveEntrada && ValorAtual == 0 && AllowNullValue)
        {
            Value = null;
        }
    }

    private void Entrada_PropertyChanged(object sender, EventArgs e)
    {
        teveEntrada = true;
        decimal? valorPadrao = null;

        if (!string.IsNullOrEmpty(Entrada.Text))
        {
            var listaChar = string.Join("", Regex.Split(Entrada.Text, @"[^\-?\d]"));

            if (ValideNovoValor(listaChar))
            {
                double.TryParse(listaChar, out double valor);

                valorPadrao = (decimal)(valor / Math.Pow(10, CasasDecimais));
            }
            else
            {
                if (OcultarPontoMilhar)
                    Entrada.Text = string.Format(ObtenhaMascara(CasasDecimais), ValorAtual).Replace(".", "");
                else
                    Entrada.Text = string.Format(ObtenhaMascara(CasasDecimais), ValorAtual);
                return;
            }
        }

        if (valorPadrao == ValorAtual) return;
        else Value = valorPadrao;
    }

    private bool ValideNovoValor(string listaChar)
    {
        if (listaChar.Length > 16)
            return false;

        double.TryParse(listaChar, out double valor);
        var valorReal = (decimal)(valor / Math.Pow(10, CasasDecimais));

        if (MaxValue != null && valorReal > MaxValue)
            return false;

        if (MinValue != null && valorReal < MinValue)
            return false;

        return true;
    }

    private void Entrada_ClearIconClicked(object sender, System.ComponentModel.HandledEventArgs e)
    {
        ValorAtual = AllowNullValue ? null : 0;

        if (!AllowNullValue)
        {
            if (OcultarPontoMilhar)
                Entrada.Text = string.Format(ObtenhaMascara(CasasDecimais), ValorAtual).Replace(".", "");
            else
                Entrada.Text = string.Format(ObtenhaMascara(CasasDecimais), ValorAtual);
        }
        else
        {
            Entrada.Text = "";
        }
    }

    public static BindableProperty ClearIconVisibilityProperty =
        BindableProperty.Create(nameof(ClearIconVisibility), typeof(IconVisibility), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty HasErrorProperty =
        BindableProperty.Create(nameof(HasError), typeof(bool), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);
    public static BindableProperty NeedBiggerThanZeroProperty =
  BindableProperty.Create(nameof(NeedBiggerThanZero), typeof(bool), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty AllowNullValueProperty =
        BindableProperty.Create(nameof(AllowNullValue), typeof(bool), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty IsRequiredProperty =
        BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty LabelTextProperty =
        BindableProperty.Create(nameof(LabelText), typeof(string), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty ErrorTextProperty =
        BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty CasasDecimaisProperty =
        BindableProperty.Create(nameof(CasasDecimais), typeof(int), typeof(NumericFormEdit), defaultValue: 2, defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(decimal?), typeof(NumericFormEdit), propertyChanged: ValuePorpertyChanged, defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(MaxValue), typeof(decimal?), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty MinValueProperty =
        BindableProperty.Create(nameof(MinValue), typeof(decimal?), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty ValueChangedCommandProperty =
        BindableProperty.Create(nameof(ValueChangedCommand), typeof(ICommand), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty ValueChangedCommandParameterProperty =
        BindableProperty.Create(nameof(ValueChangedCommandParameter), typeof(object), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty TextHorizontalAlignmentProperty =
        BindableProperty.Create(nameof(TextHorizontalAlignment), typeof(TextAlignment?), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay, defaultValue: TextAlignment.Start);

    //public static readonly BindableProperty PropertyNameProperty =
    //    BindableProperty.Create(nameof(PropertyName), typeof(string), typeof(NumericFormEdit), defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty OcultarPontoMilharProperty =
        BindableProperty.Create(nameof(OcultarPontoMilhar), typeof(bool), typeof(NumericFormEdit), defaultValue: false, defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty PrefixProperty =
        BindableProperty.Create(nameof(Prefix), typeof(string), typeof(NumericFormEdit), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay);

    public static BindableProperty SuffixProperty =
        BindableProperty.Create(nameof(Suffix), typeof(string), typeof(NumericFormEdit), defaultValue: string.Empty, defaultBindingMode: BindingMode.TwoWay);


    public string Prefix
    {
        get { return (string)GetValue(PrefixProperty); }
        set { SetValue(PrefixProperty, value); }
    }

    public string Suffix
    {
        get { return (string)GetValue(SuffixProperty); }
        set { SetValue(SuffixProperty, value); }
    }

    public bool OcultarPontoMilhar
    {
        get { return (bool)GetValue(OcultarPontoMilharProperty); }
        set { SetValue(OcultarPontoMilharProperty, value); }
    }

    //public string PropertyName
    //{
    //    get { return ResourceUtils.GetNameOfBinding(this, ValueProperty); }
    //    set { SetValue(PropertyNameProperty, value); }
    //}

    public IconVisibility ClearIconVisibility
    {
        get { return (IconVisibility)GetValue(ClearIconVisibilityProperty); }
        set { SetValue(ClearIconVisibilityProperty, value); }
    }
    public bool HasError
    {
        get { return (bool)GetValue(HasErrorProperty); }
        set { SetValue(HasErrorProperty, value); }
    }
    public bool NeedBiggerThanZero
    {
        get { return (bool)GetValue(NeedBiggerThanZeroProperty); }
        set { SetValue(NeedBiggerThanZeroProperty, value); }
    }
    public bool AllowNullValue
    {
        get { return (bool)GetValue(AllowNullValueProperty); }
        set { SetValue(AllowNullValueProperty, value); }
    }
    public bool IsRequired
    {
        get { return (bool)GetValue(IsRequiredProperty); }
        set { SetValue(IsRequiredProperty, value); }
    }
    public string LabelText
    {
        get { return (string)GetValue(LabelTextProperty); }
        set { SetValue(LabelTextProperty, value); }
    }
    public string ErrorText
    {
        get { return (string)GetValue(ErrorTextProperty); }
        set { SetValue(ErrorTextProperty, value); }
    }
    public int CasasDecimais
    {
        get { return (int)GetValue(CasasDecimaisProperty); }
        set { SetValue(CasasDecimaisProperty, value); }
    }
    public decimal? Value
    {
        get { return (decimal?)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public decimal? MaxValue
    {
        get { return (decimal?)GetValue(MaxValueProperty); }
        set { SetValue(MaxValueProperty, value); }
    }
    public decimal? MinValue
    {
        get { return (decimal?)GetValue(MinValueProperty); }
        set { SetValue(MinValueProperty, value); }
    }

    public ICommand ValueChangedCommand
    {
        get { return (ICommand)GetValue(ValueChangedCommandProperty); }
        set { SetValue(ValueChangedCommandProperty, value); }
    }

    public object ValueChangedCommandParameter
    {
        get { return GetValue(ValueChangedCommandParameterProperty); }
        set { SetValue(ValueChangedCommandParameterProperty, value); }
    }

    public TextAlignment? TextHorizontalAlignment
    {
        get { return (TextAlignment?)GetValue(TextHorizontalAlignmentProperty); }
        set { SetValue(TextHorizontalAlignmentProperty, value); }
    }
}