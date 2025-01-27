using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.MAUI.Pages.Base;

namespace FluxoDeCaixa.MAUI.Pages.Home;

public partial class HomeModel : BaseModels
{
    [ObservableProperty]
    DateTime date = DateTime.UtcNow;

    [NotifyPropertyChangedFor(nameof(IsDespesa))]
    [NotifyPropertyChangedFor(nameof(IsRenda))]
    [NotifyPropertyChangedFor(nameof(IsPoupanca))]
    [ObservableProperty]
    string tipoDeTransacao = "Despesa";

    public bool IsDespesa => TipoDeTransacao?.ToLower().Equals("Despesa".ToLower()) ?? false;
    public bool IsRenda => TipoDeTransacao?.ToLower().Equals("Renda".ToLower()) ?? false;
    public bool IsPoupanca => TipoDeTransacao?.ToLower().Equals("Poupança".ToLower()) ?? false;


    [NotifyPropertyChangedFor(nameof(Rendas))]
    [NotifyPropertyChangedFor(nameof(Despesas))]
    [NotifyPropertyChangedFor(nameof(Poupancas))]
    [ObservableProperty]
    List<Transacao> transacoes = new List<Transacao>();

    public List<Transacao> Rendas => Transacoes.Where(x => x.Tipo.Equals("Renda") && x.Data <= Date).ToList();
    public List<Transacao> Despesas => Transacoes.Where(x => x.Tipo.Equals("Despesa") && x.Data <= Date).ToList();
    public List<Transacao> Poupancas => Transacoes.Where(x => x.Tipo.Equals("Poupança") && x.Data <= Date).ToList();

    public HomeModel()
    {
        
    }

    [RelayCommand]
    void SetTipoTransacao(string tipo)
    {
        TipoDeTransacao = tipo;
    }
}
