namespace Domain.Entities;
public class Transaction
{
    public int TransactionID { get; set; }

    public string Description { get; set; } = string.Empty;

    public TransactionTypeEnum TransactionType { get; set; } = TransactionTypeEnum.Income;

    public DateTime Date { get; set; }
}
