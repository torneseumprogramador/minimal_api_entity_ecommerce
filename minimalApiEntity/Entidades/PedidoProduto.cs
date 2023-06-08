using System.ComponentModel.DataAnnotations;

namespace Entity.Entidades;

public record PedidoProduto
{
    [Key]
    public int Id { get; set; }

    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = default!;

    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = default!;

    public int Quantidade { get; set; }

    public double Valor { get; set; }
}