using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoDeCaixa.Domain.Entities;

[Table("operationcategory")]
public class OperationCategory : EntityControle
{

    [Key]
    [Column("operationcategoryid")]
    public string OperationCategoryID { get; set; } = "00000000-0000-0000-0000-080000000000";

    [Required]
    [StringLength(255)]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [StringLength(7)]
    [Column("colorhex")]
    public string ColorHex { get; set; } = "#000000";

    [StringLength(155)]
    [Column("faicon")]
    public string FAIcon { get; set; } = "cart-shopping";

    public OperationCategory()
    {
        
    }
}
