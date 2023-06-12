using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercio.WebApi.Minimal.Ecommerce.Models;

[Table("Orders")]
public class OrderModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public virtual CustomerModel Customer { get; set; }

    [Required]
    [Column(TypeName = "TEXT")]
    public DateTime OrderDate { get; set; }

    [Required]
    [Column(TypeName = "REAL")]
    public decimal TotalAmount { get; set; }

    public virtual ICollection<OrderProductModel> OrderProducts { get; set; }
}