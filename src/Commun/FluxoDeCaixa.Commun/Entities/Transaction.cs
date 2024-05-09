using FluxoDeCaixa.Commun.Enums;

namespace FluxoDeCaixa.Commun.Entities;

[Table("transaction")]
public class Transaction : Entity
{
    [Column(TypeName ="character varying(255)")]
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "integer")] 
    public int TransactionType { get; set; }

    [Column(TypeName = "decimal")]
    public decimal Value { get; set; } = 0;

    [Column(TypeName = "datetimeoffset")]
    public DateTime TransactionDate { get; set; } = DateTime.Now;

    public Transaction()
    {
            
    }

}
