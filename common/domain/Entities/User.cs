using FluxoDeCaixa.Domain.ValueObjects;

namespace FluxoDeCaixa.Domain.Entities;

[Table("user")]
public class User : EntityControl
{
    [Required]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

}
