namespace FluxoDeCaixa.Mobile.Core.Domain.Entities;

public class Account
{
    public Guid AccountId { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}
