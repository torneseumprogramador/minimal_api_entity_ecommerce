namespace douglas_felipe_william.Models;

public class PedidoProduto{

    public int Id {get;set;}
    public int PedidoId {get;set;}
    public int ProdutoId {get;set;}
    public int Quantidade {get;set;}
    public float ValorItem {get;set;}
}