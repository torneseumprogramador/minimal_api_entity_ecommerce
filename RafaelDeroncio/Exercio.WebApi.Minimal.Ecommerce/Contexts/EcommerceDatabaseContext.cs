using Microsoft.EntityFrameworkCore;

namespace Exercio.WebApi.Minimal.Ecommerce.Contexts;

public class EcommerceDatabaseContext : DbContext
{
    public EcommerceDatabaseContext(DbContextOptions<EcommerceDatabaseContext> options) : base(options)
    {
        
    }
}