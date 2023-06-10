namespace Exercio.WebApi.Minimal.Ecommerce.Requests;

public class CustomerRequest
{
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string IdentificationDoc { get; set; }
    public string Address { get; set; }
    public string RegisterDate { get; set; }
}