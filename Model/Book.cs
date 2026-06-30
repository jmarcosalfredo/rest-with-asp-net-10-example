using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rest_with_asp_net_10_example.Model;

[Table("books")]
public class Book
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

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
    public DateTime LauchDate { get; set; }
}
