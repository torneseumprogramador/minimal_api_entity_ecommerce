namespace Cairo.ModelViews;

public struct PedidoView
{
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public string NomeProduto { get; set; }
    public double ValorProduto { get; set; }
    public double ValorPedido { get; set; }
    public DateTime DataPedido { get; set; }

}
