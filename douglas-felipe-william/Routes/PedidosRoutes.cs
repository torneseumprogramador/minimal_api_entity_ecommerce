using douglas_felipe_william.Contexto;
using douglas_felipe_william.Controllers;
using douglas_felipe_william.Models;

namespace douglas_felipe_william.Routes
{
    class PedidosRoutes
    {
        private readonly WebApplication _app;
        private readonly BancoDeDadosContexto _dbContext;

        public PedidosRoutes(WebApplication app, BancoDeDadosContexto dbContext)
        {
            _app = app;
            _dbContext = dbContext;
        }

        public void Register()
        {
            _app.MapGet("/pedido/", () => new PedidosController(_dbContext).Get()).WithName("Pedido.Get").WithOpenApi();
            _app.MapPost("/pedido/", (Pedido pedido) => new PedidosController(_dbContext).Post(pedido)).WithName("Pedido.Post").WithOpenApi();
            _app.MapPut("/pedido/{id}", (int id, Pedido pedido) => new PedidosController(_dbContext).Put(id, pedido)).WithName("Pedido.Put").WithOpenApi();
            _app.MapDelete("/pedido/{id}", (int id) => new PedidosController(_dbContext).Delete(id)).WithName("Pedido.Delete").WithOpenApi();
            _app.MapGet("/pedido/{id}", (int id) => new PedidosController(_dbContext).GetByID(id)).WithName("Pedido.GetByID").WithOpenApi();
        }
    }
}
