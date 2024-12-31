using FluxoDeCaixa.Domain.Enums;
using FluxoDeCaixa.Domain.ValueObjects;

namespace FluxoDeCaixa.Domain.Entities
{
    [Table("cashflowtransaction")]
    public class CashFlowTransaction : EntityControl
    {
        [Required]
        [Column("description")]
        [StringLength(80)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("transactiondate")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column("amount", TypeName = "numeric(18,5)")]
        public decimal Amount { get; set; } = 0;

        [Required]
        [Column("transactiontype", TypeName = "integer")]
        public TransactionTypeEnum TransactionType { get; set; } = TransactionTypeEnum.RENDA;

        [Required]
        [Column("cashflowid")]
        public string CashFlowID { get; set; } = string.Empty;

        [ForeignKey(nameof(CashFlowID))]
        public virtual CashFlow CashFlowEntity { get; set; }
    }
}
