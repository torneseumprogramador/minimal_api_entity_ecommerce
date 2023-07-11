
using Cairo.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cairo.Contexto;

public class BancoDeDadosContexto : DbContext
{
    public BancoDeDadosContexto(DbContextOptions<BancoDeDadosContexto> options) : base(options)
    {

    }
    public BancoDeDadosContexto()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseMySql(configuration.GetConnectionString("conexao"),
                new MySqlServerVersion(new Version(8, 0, 33)));
        }

    }

    public DbSet<Cliente> Clientes { get; set; } = default!;
    public DbSet<Pedido> Pedidos { get; set; } = default!;
    public DbSet<PedidoProduto> PedidosProdutos { get; set; } = default!;
    public DbSet<Produto> Produtos { get; set; } = default!;


}
