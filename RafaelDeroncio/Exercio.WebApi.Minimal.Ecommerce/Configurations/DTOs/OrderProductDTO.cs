namespace Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;

public class OrderProductDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
