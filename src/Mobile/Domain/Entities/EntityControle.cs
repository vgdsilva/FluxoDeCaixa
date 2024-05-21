namespace FluxoDeCaixa.Domain.Entities;
public class EntityControle
{
    public static string GenerateUniqueIdentifier() => Guid.NewGuid().ToString();

    public static string NewUniqueIdentifier()
    {
        return "00000000-0000-0000-0000-080000000000";
    }
}
