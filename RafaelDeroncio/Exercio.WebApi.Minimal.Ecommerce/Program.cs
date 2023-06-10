using Exercio.WebApi.Minimal.Ecommerce.Routes;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
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