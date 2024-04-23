using FluxoDeCaixa.Mobile.Core.Domain.Enums;

namespace FluxoDeCaixa.Mobile.Core.Domain.Entities;

public class Category
{
    public string Description { get; set; } = string.Empty;
    public TransactionTypeEnum TransactionType { get; set; } = TransactionTypeEnum.Expense;
    public string Icon { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
}
