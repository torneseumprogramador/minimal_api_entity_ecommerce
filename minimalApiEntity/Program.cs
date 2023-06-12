using Entity.Contexto;
using Entity.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// #2 - Configurando a conexão através de injeção de dependência - Estratégia mais utilizada webapi
// É injetado através do ([FromServices] BancoDeDadosContexto contexto)
builder.Services.AddDbContext<BancoDeDadosContexto>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("conexao"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", ([FromServices] BancoDeDadosContexto contexto) =>
{
    var clientes = contexto.Clientes.ToList();

    if (clientes.Count == 0)
    {
        return Results.NotFound(new { Mensagem = "Clientes não encontrados" });
    }

    return Results.Ok(clientes);
})
.WithOpenApi();

app.MapGet("/clientes-com-pedidos", ([FromServices] BancoDeDadosContexto contexto, [FromQuery] int? page) =>
{
    int totalPage = 10;

    if (page == null || page < 1)
        page = 1;

    int offset = ((int)page - 1) * totalPage;

    /*var relatorioEntity = contexto.Pedidos
                            .Include(p => p.Cliente)
                            .Select(p => new PedidoCliente
                            {
                                Nome = p.Cliente.Nome,
                                Telefone = p.Cliente.Telefone,
                                ValorTotal = p.ValorTotal
                            });*/

    /*var relatorioEntity = contexto.Clientes
                             .Join(contexto.Pedidos,
                                     cli => cli.Id,
                                     ped => ped.ClienteId,
                                     (cli, ped) => new
                                     {
                                         Cliente = cli,
                                         Pedido = ped
                                     })
                             .Join(contexto.PedidosProdutos,
                                     c => c.Pedido.Id,
                                     pp => pp.PedidoId,
                                     (c, pp) => new
                                     {
                                         c.Cliente,
                                         c.Pedido,
                                         PedidoProduto = pp
                                     })
                             .Join(contexto.Produtos,
                                     c => c.PedidoProduto.ProdutoId,
                                     pro => pro.Id,
                                     (c, pro) => new PedidoCliente
                                     {
                                         Nome = c.Cliente.Nome,
                                         Telefone = c.Cliente.Telefone,
                                         ValorTotal = c.Pedido.ValorTotal,
                                         NomeProduto = pro.Nome,
                                         QuantidadeVendidaParaProduto = c.PedidoProduto.Quantidade,
                                         ValorVendidoParaProduto = c.PedidoProduto.Valor
                                     }); */

    var relatorioEntity = from cli in contexto.Clientes
                          join ped in contexto.Pedidos
                              on cli.Id equals ped.Id
                          join pp in contexto.PedidosProdutos
                              on ped.Id equals pp.PedidoId
                          join pro in contexto.Produtos
                              on pp.ProdutoId equals pro.Id
                          select new PedidoCliente
                          {
                              Nome = cli.Nome,
                              Telefone = cli.Telefone,
                              ValorTotal = ped.ValorTotal,
                              NomeProduto = pro.Nome,
                              QuantidadeVendidaParaProduto = pp.Quantidade,
                              ValorVendidoParaProduto = pp.Valor
                          };

    List<PedidoCliente> lista = relatorioEntity.Skip(offset).Take(totalPage).ToList();

    if (lista.Count == 0)
    {
        return Results.NotFound(new { Mensagem = "Clientes não encontrados" });
    }

    RegistroPaginado<PedidoCliente> listaPaginada = new RegistroPaginado<PedidoCliente>
    {
        Registros = lista,
        TotalPorPagina = totalPage,
        PaginaCorrente = (int)page,
        TotalRegistros = relatorioEntity.Count()
    };

    return Results.Ok(listaPaginada);
})
.WithOpenApi();

app.Run();
