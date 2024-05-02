using AndroidX.ConstraintLayout.Core.Widgets.Analyzer;

namespace FluxoDeCaixa.Mobile.Core.Domain.Entities;

public class Coin
{
    public Guid CoinId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string Simbolo { get; set; } = string.Empty;

    public char ThousandGroupingSymbol { get; set; } = '.';

    public char DecimalGroupingSymbol { get; set; } = ',';
}
