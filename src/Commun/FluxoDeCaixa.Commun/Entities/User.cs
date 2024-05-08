namespace FluxoDeCaixa.Commun.Entities;

[Table("user")]
public class User : Entity
{
    public string Name { get; set; } = string.Empty;

    public User()
    {
        
    }
}
