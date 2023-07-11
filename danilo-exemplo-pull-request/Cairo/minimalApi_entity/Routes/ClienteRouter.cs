using Cairo.Contexto;
using Cairo.Resources;

namespace Cairo.Routes;

public class ClienteRouter
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/clientes", ClienteResource.GetAll).WithName("BuscarClientes").WithOpenApi();
        app.MapGet("/cliente/{id}", ClienteResource.GetId).WithName("BuscarClientePorId").WithOpenApi();
        app.MapPost("/cliente/cadastro", ClienteResource.Post).WithName("CadastrarCliente").WithOpenApi();
        app.MapDelete("/cliente/{id}/excluir", ClienteResource.DeleteId).WithName("ExcluirAluno").WithOpenApi();
    }
}
