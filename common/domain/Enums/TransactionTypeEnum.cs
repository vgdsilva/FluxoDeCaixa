namespace FluxoDeCaixa.Domain.Enums;

public enum TransactionTypeEnum
{
    [Display(Name = "Renda")]
    RENDA = 0,

    [Display(Name = "Despesa")]
    DESPESA = 1,

    [Display(Name = "Poupança")]
    POUPANCA = 2,
}
