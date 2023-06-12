using douglas_felipe_william.Contexto;
using douglas_felipe_william.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace douglas_felipe_william.Controllers
{
    public class ClientesController
    {
        private readonly BancoDeDadosContexto _dbContext;

        public ClientesController(BancoDeDadosContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public object Get()
        {
            var clientes = _dbContext.Clientes.ToList();
            return clientes;
        }

        public object Post(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
            return new { mensagem = "Adicionado com sucesso na lista de clientes" };
        }

        public object Put(int id, Cliente cliente)
        {
            var clienteExistente = _dbContext.Clientes.FirstOrDefault(a => a.Id == id);
            if (clienteExistente != null)
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.CPF = cliente.CPF;
                clienteExistente.Celular = cliente.Celular;
                _dbContext.SaveChanges();
                return new { mensagem = "Cliente atualizado com sucesso" };
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }

        public object Delete(int id)
        {
            var clienteExistente = _dbContext.Clientes.FirstOrDefault(a => a.Id == id);
            if (clienteExistente != null)
            {
                _dbContext.Clientes.Remove(clienteExistente);
                _dbContext.SaveChanges();
                return new { mensagem = "Cliente removido com sucesso" };
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }

        public object GetByID(int id)
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(a => a.Id == id);
            if (cliente != null)
            {
                return cliente;
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }
    }
}
