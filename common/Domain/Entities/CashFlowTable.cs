namespace Domain.Entities;

public class CashFlowTable
{
    public string CashFlowID { get; set; } = Guid.Empty.ToString();

    public string Description { get; set; } = string.Empty;
}
