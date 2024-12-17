using FluxoDeCaixa.Domain.ValueObjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoDeCaixa.Domain.Entities;


[Table("usuario")]
public class Usuario : EntityControl
{
    [Required]
    [Column("name")]
    public string Nome { get; set; } = string.Empty;

    [Column("email")]
    [StringLength(80)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("senha")]
    [StringLength(30)]
    public string Senha { get; set; } = string.Empty;

    [Column("root", TypeName = "numeric(5,0)")]
    [DefaultValue(0)]
    public int Root { get; set; }

    [Column("imagem", TypeName = "bytea")]
    public byte[] Imagem { get; set; }

    [Column("ativo", TypeName = "numeric(5,0)")]
    [DefaultValue("1")]
    public int Ativo { get; set; } = 1;
}
