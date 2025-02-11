using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.MAUI.Pages.Base;
using FluxoDeCaixa.MAUI.Utils.Classes;
using System.Collections.ObjectModel;
using System.Globalization;

namespace FluxoDeCaixa.MAUI.Pages.Home;

public partial class HomeModel : BaseModels
{

    [ObservableProperty]
    string username;

    [ObservableProperty]
    ObservableCollection<OverviewData> overviewData;


    [ObservableProperty]
    DateTime date = DateTime.UtcNow;

    //[NotifyPropertyChangedFor(nameof(IsDespesa))]
    //[NotifyPropertyChangedFor(nameof(IsRenda))]
    //[NotifyPropertyChangedFor(nameof(IsPoupanca))]
    //[ObservableProperty]
    //string tipoDeTransacao = "Despesa";

    //public bool IsDespesa => TipoDeTransacao?.ToLower().Equals("Despesa".ToLower()) ?? false;
    //public bool IsRenda => TipoDeTransacao?.ToLower().Equals("Renda".ToLower()) ?? false;
    //public bool IsPoupanca => TipoDeTransacao?.ToLower().Equals("Poupança".ToLower()) ?? false;


    //[NotifyPropertyChangedFor(nameof(Rendas))]
    //[NotifyPropertyChangedFor(nameof(Despesas))]
    //[NotifyPropertyChangedFor(nameof(Poupancas))]
    //[ObservableProperty]
    //List<Transacao> transacoes = new List<Transacao>();

    //public List<Transacao> Rendas => Transacoes.Where(x => x.Tipo.Equals("Renda")).ToList();
    //public List<Transacao> Despesas => Transacoes.Where(x => x.Tipo.Equals("Despesa")).ToList();
    //public List<Transacao> Poupancas => Transacoes.Where(x => x.Tipo.Equals("Poupança")).ToList();



    public HomeModel()
    {
        Username = Configurations.Get(ConfigurationsEnum.Username, "Convidado");
        overviewData = 
        [
            new OverviewData() { Title = "Valor Total", Value = 0.00m },
            new OverviewData() { Title = "Saldo Entradas", Value = 0.00m },
            new OverviewData() { Title = "Saldo Saidas", Value = 0.00m },
        ];
    }

    //[RelayCommand]
    //void SetTipoTransacao(string tipo)
    //{
    //    TipoDeTransacao = tipo;
    //}

}

public class OverviewData
{
    public string Title { get; set; }
    public decimal Value { get; set; } = 0.00m;
    public string FormatedValue => Value.ToString("C", new CultureInfo("pt-BR"));
}
