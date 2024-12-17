using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.BlogDomain;

public class Blog : Auditable
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "string")]
    [Required, MinLength(1, ErrorMessage = "Minimum of 1 character allowed"), MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
    public string Title { get; set; }

    [Column(TypeName = "text")]
    [Required, MinLength(1, ErrorMessage = "Minimum of 1 character allowed"), MaxLength(1000, ErrorMessage = "Maximum of 1000 characters allowed")]
    public string Content { get; set; }

    [Column(TypeName = "smallint")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; } = 1;

    [JsonPropertyOrder(1)]
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
