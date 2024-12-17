using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluxoDeCaixa.Domain.ValueObjects
{
    public abstract class EntityControl
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty;

        [Column("created_at", TypeName = "timestamp with time zone")]
        [DefaultValue("now()")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "timestamp with time zone")]
        [DefaultValue("now()")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public string __TableName => GetType().Name.ToUpper();
    }
}
