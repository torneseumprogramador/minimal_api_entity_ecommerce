using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo.Entidades;

[Table("pedidos")]
public record Pedido
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column(name: "id")]
    public int Id { get; set; }

    [Column(name: "cliente_id")]
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = default!;

    [Column(name: "valor_pedido")]
    public double ValorPedido { get; set; }

    [Column(name: "data")]
    public DateTime Data { get; set; }

}
