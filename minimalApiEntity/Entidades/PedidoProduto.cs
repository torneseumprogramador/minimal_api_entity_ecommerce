using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entidades;

[Table("pedidos_produtos")]
public record PedidoProduto
{
    [Key]
    [Column(name: "id")]
    public int Id { get; set; }

    [Column(name: "pedido_id")]
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = default!;

    [Column(name: "produto_id")]
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = default!;

    [Column(name: "quantidade")]
    public int Quantidade { get; set; }

    [Column(name: "valor")]
    public double Valor { get; set; }
}