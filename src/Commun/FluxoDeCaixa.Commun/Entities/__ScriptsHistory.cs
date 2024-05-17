namespace FluxoDeCaixa.Commun.Entities;

[Table("__scriptshistory")]
public class __ScriptsHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("scriptid", TypeName = "bigint")]
    public string ScriptID { get; set; } = string.Empty;

    [Column("script")]
    [StringLength(100000)]
    [Required]
    public string Script { get; set; } = string.Empty;
}
