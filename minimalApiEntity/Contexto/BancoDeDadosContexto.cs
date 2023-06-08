using Entity.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entity.Contexto;

public class BancoDeDadosContexto : DbContext
{
    // #3 - Passando a dependencia do banco de dados via construtor
    public BancoDeDadosContexto(DbContextOptions<BancoDeDadosContexto> options) : base(options)
    {
    }

    public BancoDeDadosContexto() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // #1 - Caso não tenha sido configurado na classe Program ele entra no if
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("conexao"));
        }
    }

    public DbSet<Cliente> Clientes { get; set; } = default!;
}