using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercio.WebApi.Minimal.Ecommerce.Models;

[Table("Customers")]
public class CustomerModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "TEXT")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "TEXT")]
    public string PhoneNumber { get; set; }

    [Required]
    [Column(TypeName = "TEXT")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "TEXT")]
    public string IdentificationDoc { get; set; }

    [Required]
    [Column(TypeName = "TEXT")]
    public string Address { get; set; }

    [Required]
    [Column(TypeName = "TEXT")]
    public DateTime RegisterDate { get; set; }

    public virtual ICollection<OrderModel> Orders { get; set; }
}