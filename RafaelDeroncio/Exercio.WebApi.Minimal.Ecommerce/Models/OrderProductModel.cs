using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercio.WebApi.Minimal.Ecommerce.Models;

[Table("Order_Products")]
public class OrderProductModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    public virtual OrderModel Order { get; set; }

    [Required]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public virtual ProductModel Product { get; set; }

    [Required]
    public int Quantity { get; set; }
}