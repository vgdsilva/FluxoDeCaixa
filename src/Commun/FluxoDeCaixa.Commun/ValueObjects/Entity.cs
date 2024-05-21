using FluxoDeCaixa.Commun.Utils;

namespace FluxoDeCaixa.Commun.ValueObjects;
public class Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = EntityUtils.GenerateUniqueIdentifier();
}
