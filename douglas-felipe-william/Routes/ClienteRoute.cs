using douglas_felipe_william.Contexto;
using douglas_felipe_william.Controllers;
using douglas_felipe_william.Models;

namespace douglas_felipe_william.Routes;

class ClienteRoute
{
    private readonly WebApplication _app;
    private readonly BancoDeDadosContexto _dbContext;

    public ClienteRoute(WebApplication app, BancoDeDadosContexto dbContext)
    {
        _app = app;
        _dbContext = dbContext;
    }

    public void Register()
    {
        _app.MapGet("/cliente/", () => new ClientesController(_dbContext).Get()).WithName("Cliente.Get").WithOpenApi();
        _app.MapPost("/cliente/", (Cliente Cliente) => new ClientesController(_dbContext).Post(Cliente)).WithName("Cliente.Post").WithOpenApi();
        _app.MapPut("/cliente/{id}", (int id, Cliente Cliente) => new ClientesController(_dbContext).Put(id, Cliente)).WithName("Cliente.Put").WithOpenApi();
        _app.MapDelete("/cliente/{id}", (int id) => new ClientesController(_dbContext).Delete(id)).WithName("Cliente.Delete").WithOpenApi();
        _app.MapGet("/cliente/{id}", (int id) => new ClientesController(_dbContext).GetByID(id)).WithName("Cliente.GetByID").WithOpenApi();
    }
}
