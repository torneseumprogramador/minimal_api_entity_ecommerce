using Exercio.WebApi.Minimal.Ecommerce.Contexts;
using Exercio.WebApi.Minimal.Ecommerce.Extensions;
using Exercio.WebApi.Minimal.Ecommerce.Routes;
using Exercio.WebApi.Minimal.Ecommerce.Services;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Configure DbContext Sqlite
builder.Services.AddDbContext<EcommerceDatabaseContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection", true)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

new CustomerRoute(app).Register();
new ProductRoute(app).Register();
new OrderRoute(app).Register();

app.Run();
