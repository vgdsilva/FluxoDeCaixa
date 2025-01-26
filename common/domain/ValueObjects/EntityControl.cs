namespace FluxoDeCaixa.Domain.ValueObjects;

public abstract class EntityControl
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; } = Guid.Empty;

    [Column("createdat", TypeName = "timestamp with time zone")]
    [DefaultValue("now()")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updatedat", TypeName = "timestamp with time zone")]
    [DefaultValue("now()")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    public string __TableName => GetType().Name.ToUpper();
}
