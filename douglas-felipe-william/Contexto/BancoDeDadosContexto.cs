using Microsoft.EntityFrameworkCore;
using douglas_felipe_william.Models;

namespace douglas_felipe_william.Contexto;

public class BancoDeDadosContexto : DbContext
{ 
    public BancoDeDadosContexto(DbContextOptions<BancoDeDadosContexto> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Produto> Produtos { get; set; } = default!;
    public DbSet<Pedido> Pedidos { get; set; } = default!;
    public DbSet<PedidoProduto> PedidosProdutos { get; set; } = default!;
}