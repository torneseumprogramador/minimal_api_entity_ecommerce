namespace douglas_felipe_william.Models;

public class Pedido{

    public int Id {get;set;}
    public int ClienteId {get;set;}
    public DateTime? Data {get;set;}
    public float? ValorTotal {get;set;}
}