using Entity.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entity.Contexto;

public class BancoDeDadosContexto : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("conexao"));
    }
    public DbSet<Cliente> Clientes { get; set; } = default!;
}