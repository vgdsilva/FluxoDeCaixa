using FluxoDeCaixa.MAUI.Views.Pages.Base;
using System.Collections.ObjectModel;
using System.Globalization;

namespace FluxoDeCaixa.MAUI.Views.Pages.Home;

public partial class HomeModel : BaseModels
{

    [ObservableProperty]
    string username;

    [ObservableProperty]
    ObservableCollection<OverviewData> overviewData;

    [ObservableProperty]
    DateTime date = DateTime.UtcNow;

    [ObservableProperty]
    ObservableCollection<Transacao> historicoTransacoesList;


    public HomeModel()
    {
        OverviewData = 
        [
            new OverviewData() { Title = "Entradas", Value = 0.00m },
            new OverviewData() { Title = "Saidas", Value = 0.00m },
            new OverviewData() { Title = "Total", Value = 0.00m, BackgroundColor = "#015F43" },
        ];
    }

    public void LoadData(List<Transacao> historicoTransacoes/*, List<Transacao> transacoesPlanejadas*/)
    {
        HistoricoTransacoesList = new ObservableCollection<Transacao>(historicoTransacoes);

        var Entradas = historicoTransacoes.Where(x => x.Tipo == 0).Sum(x => x.Valor);
        var Saidas = historicoTransacoes.Where(x => x.Tipo == 1).Sum(x => x.Valor);

        OverviewData =
        [
            new OverviewData("Entradas", Entradas),
            new OverviewData("Saidas", Saidas),
            new OverviewData("Total", Entradas - Saidas, "#015F43"),
        ];
    }
}

public class OverviewData
{
    public string BackgroundColor { get; set; } = "#323238"; 
    public string Title { get; set; } = string.Empty;
    public decimal Value { get; set; } = 0.00m;
    public string FormatedValue => Value.ToString("C", new CultureInfo("pt-BR"));

    public OverviewData()
    {
        
    }

    public OverviewData(string title, decimal value, string backgroundColor = "#323238")
    {
        this.Title = title;
        this.Value = value;
        this.BackgroundColor = backgroundColor;
    }
}
