using douglas_felipe_william.Contexto;
using douglas_felipe_william.Controllers;
using douglas_felipe_william.Models;

namespace douglas_felipe_william.Routes
{
    class PedidosProdutosRoutes
    {
        private readonly WebApplication _app;
        private readonly BancoDeDadosContexto _dbContext;

        public PedidosProdutosRoutes(WebApplication app, BancoDeDadosContexto dbContext)
        {
            _app = app;
            _dbContext = dbContext;
        }

        public void Register()
        {
            _app.MapGet("/pedido/{pedidoId}/produto/", (int pedidoId) => new PedidoProdutosController(_dbContext).Get(pedidoId)).WithName("PedidoProduto.Get").WithOpenApi();
            _app.MapPost("/pedido/{pedidoId}/produto/", (int pedidoId, PedidoProduto pedidoProduto) => new PedidoProdutosController(_dbContext).Post(pedidoId, pedidoProduto)).WithName("PedidoProduto.Post").WithOpenApi();
            _app.MapPut("/pedido/{pedidoId}/produto/{id}", (int pedidoId, int id, PedidoProduto pedidoProduto) => new PedidoProdutosController(_dbContext).Put(pedidoId, id, pedidoProduto)).WithName("PedidoProduto.Put").WithOpenApi();
            _app.MapDelete("/pedido/{pedidoId}/produto/{id}", (int pedidoId, int id) => new PedidoProdutosController(_dbContext).Delete(pedidoId, id)).WithName("PedidoProduto.Delete").WithOpenApi();
        }
    }
}
