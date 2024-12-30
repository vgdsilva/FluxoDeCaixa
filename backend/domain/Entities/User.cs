using FluxoDeCaixa.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoDeCaixa.Domain.Entities;


[Table("user")]
public class User : EntityControl
{
    [Required]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("email")]
    [StringLength(80)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("password")]
    [StringLength(30)]
    public string Password { get; set; } = string.Empty;

    [Column("root", TypeName = "numeric(5,0)")]
    [DefaultValue(0)]
    public int Root { get; set; }

    [Column("image", TypeName = "bytea")]
    public byte[] Image { get; set; }

    [Column("active", TypeName = "numeric(5,0)")]
    [DefaultValue("1")]
    public int Active { get; set; } = 1;
}
