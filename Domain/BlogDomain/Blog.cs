using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.BlogDomain;

public class Blog
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "string")]
    [Required, MinLength(1, ErrorMessage = "Minium of 1 characters allowed"), MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
    public string Title { get; set; }

    [Column(TypeName = "text")]
    [Required, MinLength(1, ErrorMessage = "Minium of 1 characters allowed"), MaxLength(1000, ErrorMessage = "Maximum of 1000 characters allowed")]
    public string Content { get; set; }

    [Column(TypeName = "DateTime2")]
    [JsonPropertyName("created_at")]
    public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "DateTime2")]
    [JsonPropertyName("updated_at")]
    public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
