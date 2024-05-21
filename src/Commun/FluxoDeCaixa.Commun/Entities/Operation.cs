namespace FluxoDeCaixa.Commun.Entities;

[Table("operation")]
public class Operation
{ 

    [Key]
    [Column("operationid", TypeName = "text")]
    public string OperationID { get; set; }

    [Column("description", TypeName = "character varying(255)")]
    public string Description { get; set; } = string.Empty;

    [Column("operationtype", TypeName = "integer")]
    public int OperationType { get; set; }

    [Column("value", TypeName = "decimal")]
    public decimal Value { get; set; } = 0;

    [Column("transactiondate", TypeName = "datetimeoffset")]
    public DateTime OperationDate { get; set; } = DateTime.Now;

    public Operation()
    {
        
    }
}
