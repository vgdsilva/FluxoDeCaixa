using FluxoDeCaixa.Domain.ValueObjects;

namespace FluxoDeCaixa.Domain.Entities;

[Table("transacao")]
public class Transacao : EntityControl
{
    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("valor")]
    public decimal Valor { get; set; } = 0;

    [Column("data")]
    public DateTime Data { get; set; } = DateTime.UtcNow;

    [Column("tipo")]
    public int Tipo { get; set; } = 1;

    public Transacao()
    {
        
    }

    public Transacao(string descricao, decimal valor, DateTime data, int tipo)
    {
        Tipo = tipo;
        Descricao = descricao;
        Valor = valor;
        Data = data;
    }

    public override string ToString()
    {
        string tipo = Tipo == 0 ? "Renda" : "Despesa";
        return $"{Data.ToShortDateString()} - {Descricao}: {Valor:C} ({tipo})";
    }
}
