using Exercio.WebApi.Minimal.Ecommerce.Routes;
using Exercio.WebApi.Minimal.Ecommerce.Services;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IOrderService, OrderService>();

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