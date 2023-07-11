using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cairo.Entidades;

[Table("pedidosProdutos")]
public record PedidoProduto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column(name: "id")]
    public int Id { get; set; }

    [Column(name: "pedido_id")]
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = default!;

    [Column(name: "produto_id")]
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = default!;
}
