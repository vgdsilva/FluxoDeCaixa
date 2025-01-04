namespace FluxoDeCaixa.Domain.ValueObjects;

public static class Trad
{
    public static string APPLICATION_NAME(string culture = "pt-BR", params string[] formats)
    {
        switch (culture)
        {
            default: 
            case "pt-BR":
                return "Fluxo de caixa";
            case "en-US":
                return "Cash flow";
        }
    }
}
