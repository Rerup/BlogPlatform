using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BlogApi.Domain.BlogDomain;

public class Comment
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "string")]
    [Required, MinLength(1), MaxLength(255), NotNull]
    public string Content { get; set; }

    [Column(TypeName = "DateTime2")]
    public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "DateTime2")]
    public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public int BlogId { get; set; }

}
