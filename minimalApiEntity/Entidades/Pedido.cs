using System.ComponentModel.DataAnnotations;

namespace Entity.Entidades;

public record Pedido
{
    [Key]
    public int Id { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = default!;

    public double ValorTotal { get; set; }

    public DateTime Data { get; set; }
}