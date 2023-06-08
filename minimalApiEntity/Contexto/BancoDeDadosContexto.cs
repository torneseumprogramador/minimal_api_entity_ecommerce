using Entity.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Entity.Contexto;

public class BancoDeDadosContexto : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações adicionais do modelo, se necessário
    }

    public DbSet<Cliente> Clientes { get; set; } = default!;
}