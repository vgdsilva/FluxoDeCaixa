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
    public string Tipo { get; set; } = "Despesa";

    [Column("categoriaid")]
    public Guid? CategoriaId { get; set; }


    [ForeignKey(nameof(CategoriaId))]
    public virtual Categoria Categoria { get; set; }

}
