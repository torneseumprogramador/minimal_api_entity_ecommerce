namespace Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string IdentificationDoc { get; set; }
    public string Address { get; set; }
    public DateTime RegisterDate { get; set; }    
}