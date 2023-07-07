namespace Cairo.Entidades;

public record Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = default!;
    public double ValorPedido { get; set; }
    public DateTime Data { get; set; }

}
