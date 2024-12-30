using FluxoDeCaixa.Domain.ValueObjects;

namespace FluxoDeCaixa.Domain.Entities;

[Table("cashflow")]
public class CashFlow : EntityControl
{
    [Column("description")]
    [StringLength(80)]
    public string Description { get; set; } = string.Empty;

    [Column("startdate")]
    public DateTime StartDate { get; set; }

    [Column("enddate")]
    public DateTime EndDate { get; set; }

    [Required]
    [Column("userid")]
    public string UserID { get; set; } = string.Empty;


    [ForeignKey(nameof(UserID))]
    public virtual User UserEntity { get; set; }
}
