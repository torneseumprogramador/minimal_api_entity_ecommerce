using Microsoft.EntityFrameworkCore;
using douglas_felipe_william.Contexto;
using douglas_felipe_william.Models;
using douglas_felipe_william.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BancoDeDadosContexto>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var dbContext = app.Services.GetRequiredService<BancoDeDadosContexto>();
new ClienteRoute(app, dbContext).Register();

app.Run();
