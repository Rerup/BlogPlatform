using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Domain.BlogDomain;

public class Blog
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "string")]
    [Required, MinLength(1), MaxLength(30), NotNull]
    public string Title { get; set; }

    [Column(TypeName = "text")]
    [Required, MinLength(1), MaxLength(1000), NotNull]
    public string Content { get; set; }

    [Column(TypeName = "DateTime2")]
    [JsonPropertyName("created_at")]
    public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "DateTime2")]
    [JsonPropertyName("updated_at")]
    public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
