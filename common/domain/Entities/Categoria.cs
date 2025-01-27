using FluxoDeCaixa.Domain.Enums;
using FluxoDeCaixa.Domain.ValueObjects;

namespace FluxoDeCaixa.Domain.Entities;

[Table("categoria")]
public class Categoria : EntityControl
{

    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("tipotransaco")]
    public string TipoTransacao { get; set; } = "DESPESA";

    [Column("icone")]
    public string Icone { get; set; } = string.Empty;

    [Column("coricone")]
    [StringLength(12)]
    public string CorIcone { get; set; } = string.Empty;

    
    public Categoria()
    {
        
    }
}
