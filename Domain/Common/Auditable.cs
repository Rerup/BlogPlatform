using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Common;

public abstract class Auditable
{
    [Column(TypeName = "DateTime2")]
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "DateTime2")]
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public void Audit()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
