using FluxoDeCaixa.Mobile.Core.Domain.Entities;

namespace FluxoDeCaixa.Mobile.Core.Domain.Constants;

public static class Currency
{

    public static Coin REAL()
    {
        Coin real = new()
        {
            CoinId = Guid.NewGuid(),
            Description = "Real",
            Simbolo = "R$",
            DecimalGroupingSymbol = '.',
            ThousandGroupingSymbol = ','
        };

        return real;
    }

    public static Coin DOLAR()
    {
        Coin dolar = new()
        {
            CoinId = Guid.NewGuid(),
            Description = "Dolar",
            Simbolo = "US$",
            DecimalGroupingSymbol = ',',
            ThousandGroupingSymbol = '.'
        };

        return dolar;
    }

    public static Coin PESO()
    {
        Coin peso = new()
        {
            CoinId = Guid.NewGuid(),
            Description = "Peso",
            Simbolo = "$",
            DecimalGroupingSymbol = '.',
            ThousandGroupingSymbol = ','
        };

        return peso;
    }
}
