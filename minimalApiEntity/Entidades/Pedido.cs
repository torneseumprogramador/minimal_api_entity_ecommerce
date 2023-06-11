using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entidades;

[Table("pedidos")]
public record Pedido
{
    [Key]
    [Column(name: "id")]
    public int Id { get; set; }

    [Column(name: "cliente_id")]
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = default!;

    [Column(name: "valor_total")]
    public double ValorTotal { get; set; }

    [Column(name: "data")]
    public DateTime Data { get; set; }
}