using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.BlogDomain;

public class Comment : Auditable
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "string")]
    [Required, MinLength(1), MaxLength(255)]
    public string Content { get; set; }

    [JsonPropertyName("blog_id")]
    [Required]
    public int BlogId { get; set; }

}
