namespace Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
}