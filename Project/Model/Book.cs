using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rest_with_asp_net_10_example.Model.Base;

namespace rest_with_asp_net_10_example.Model;

[Table("books")]
public class Book : BaseEntity
{
    [Required]
    [Column("title", TypeName = "varchar(200)")]
    [MaxLength(200)]
    public string? Title { get; set; }

    [Required]
    [Column("author", TypeName = "varchar(250)")]
    [MaxLength(250)]
    public string? Author { get; set; }

    [Required]
    [Column("price")]
    public decimal Price { get; set; }

    [Required]
    [Column("launch_date")]
    public DateTime LaunchDate { get; set; }
}
