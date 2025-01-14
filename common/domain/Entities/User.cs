using FluxoDeCaixa.Domain.ValueObjects;

namespace FluxoDeCaixa.Domain.Entities;

[Table("user")]
public class User : EntityControl
{
    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [StringLength(255, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;
}
