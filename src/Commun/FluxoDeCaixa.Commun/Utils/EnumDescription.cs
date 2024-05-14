namespace FluxoDeCaixa.Commun;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class EnumDescription : Attribute
{
    public string Description { get; set; }

    public EnumDescription(string description)
    {
        Description = description;
    }
}
