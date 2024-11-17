using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BlogApi.Domain.BlogDomain;

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
    public virtual DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "DateTime2")]
    public virtual DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
