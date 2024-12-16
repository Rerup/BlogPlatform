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
    [Required, MinLength(1, ErrorMessage = "Minium of 1 characters allowed"), MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
    public string Title { get; set; }

    [Column(TypeName = "text")]
    [Required, MinLength(1, ErrorMessage = "Minium of 1 characters allowed"), MaxLength(1000, ErrorMessage = "Maximum of 1000 characters allowed")]
    public string Content { get; set; }

    [JsonPropertyOrder(1)]
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}
