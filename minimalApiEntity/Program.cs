using Entity.Contexto;
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
.WithName("Home")
.WithOpenApi();

app.Run();
