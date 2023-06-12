using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercio.WebApi.Minimal.Ecommerce.Models;

[Table("Products")]
public class ProductModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "TEXT")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "REAL")]
    public decimal Price { get; set; }

    public virtual ICollection<OrderProductModel> OrderProducts { get; set; }
}