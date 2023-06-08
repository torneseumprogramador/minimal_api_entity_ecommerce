using douglas_felipe_william.Contexto;
using douglas_felipe_william.Controllers;
using douglas_felipe_william.Models;

namespace douglas_felipe_william.Routes
{
    class ProdutosRoutes
    {
        private readonly WebApplication _app;
        private readonly BancoDeDadosContexto _dbContext;

        public ProdutosRoutes(WebApplication app, BancoDeDadosContexto dbContext)
        {
            _app = app;
            _dbContext = dbContext;
        }

        public void Register()
        {
            _app.MapGet("/produto/", () => new ProdutosController(_dbContext).Get()).WithName("Produto.Get").WithOpenApi();
            _app.MapPost("/produto/", (Produto produto) => new ProdutosController(_dbContext).Post(produto)).WithName("Produto.Post").WithOpenApi();
            _app.MapPut("/produto/{id}", (int id, Produto produto) => new ProdutosController(_dbContext).Put(id, produto)).WithName("Produto.Put").WithOpenApi();
            _app.MapDelete("/produto/{id}", (int id) => new ProdutosController(_dbContext).Delete(id)).WithName("Produto.Delete").WithOpenApi();
            _app.MapGet("/produto/{id}", (int id) => new ProdutosController(_dbContext).GetByID(id)).WithName("Produto.GetByID").WithOpenApi();
        }
    }
}
