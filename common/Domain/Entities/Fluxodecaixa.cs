using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("fluxodecaixa")]
public class Fluxodecaixa : BaseEntity
{
    [Key]
    [Column("idfluxodecaixa", TypeName = "text")]
    public string IDFluxodecaixa { get; set; } = EmpytID();
    public string Descricao { get; set; } = string.Empty;
    public string IDMoeda { get; set; } = EmpytID();
    public int NumeroCasasDecimais { get; set; } = 2;

    public virtual Moeda MoedaEntidade { get; set; }
}
