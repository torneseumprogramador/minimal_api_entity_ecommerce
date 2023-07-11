using Cairo.Contexto;
using Cairo.Entidades;
using Cairo.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace Cairo.Resources;

public class ClienteResource
{
    public static RetornoPaginadoView<ClienteView> GetAll([FromQuery] int? page)
    {
        var totalPage = 3;
        if (page == null || page < 1)
        {
            page = 1;
        }
        int offset = ((int)page - 1) * totalPage;

        var contexto = new BancoDeDadosContexto();

        var clientes = contexto.Clientes
            .Select(cli => new ClienteView
            {
                Nome = cli.Nome,
                Email = cli.Email
            })
            .ToList();

        var clientesPaginado = clientes.Skip(offset).Take(totalPage).ToList();

        return new RetornoPaginadoView<ClienteView>
        {
            Registros = clientesPaginado,
            TotalPorPagina = totalPage,
            PaginaCorrente = (int)page,
            TotalRegistros = clientes.Count()
        };
    }

    public static IActionResult GetId(int id)
    {
        var contexto = new BancoDeDadosContexto();

        try
        {
            var cliente = contexto.Clientes
                .Where(cli => cli.Id == id) //COndição para buscar pelo ID
                .Select(cli => new ClienteView
                {
                    Nome = cli.Nome,
                    Email = cli.Email
                })
                .FirstOrDefault(); // Buscar o primeiro cliente que corresponda à condição ou retornar null se não houver

            if (cliente.Nome != null)
            {
                return new OkObjectResult(cliente);
            }
            else
            {
                return new NotFoundResult();
            }
        }
        catch (Exception ex)
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);

        }
    }

    public static IActionResult Post([FromBody] ClienteView clienteView)
    {
        var contexto = new BancoDeDadosContexto();
        try
        {
            if (clienteView.Nome == null || clienteView.Email == null)
            {
                return new BadRequestResult();
            }

            var novoCliente = new Cliente
            {
                Nome = clienteView.Nome,
                Email = clienteView.Email
            };

            // Adicionar o novo cliente ao contexto e salvar no banco de dados
            contexto.Clientes.Add(novoCliente);
            contexto.SaveChanges();

            return new StatusCodeResult(StatusCodes.Status201Created);
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    public static IActionResult DeleteId(int id)
    {
        var contexto = new BancoDeDadosContexto();

        try
        {
            var cliente = contexto.Clientes.FirstOrDefault(cli => cli.Id == id);

            if (cliente != null)
            {
                contexto.Clientes.Remove(cliente);
                contexto.SaveChanges();

                return new NoContentResult();
            }
            else
            {
                return new NotFoundResult();
            }
        }
        catch (Exception ex)
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

    }
}
