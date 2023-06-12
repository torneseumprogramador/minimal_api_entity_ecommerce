using douglas_felipe_william.Contexto;
using douglas_felipe_william.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace douglas_felipe_william.Controllers
{
    public class PedidosController
    {
        private readonly BancoDeDadosContexto _dbContext;

        public PedidosController(BancoDeDadosContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public object Get()
        {
            var pedidos = _dbContext.Pedidos.Include(p => p.ClienteId).ToList();
            return pedidos;
        }

        public object Post(Pedido pedido)
        {
            pedido.Data = DateTime.Now;
            _dbContext.Pedidos.Add(pedido);
            _dbContext.SaveChanges();
            return new { mensagem = "Pedido adicionado com sucesso" };
        }

        public object Put(int id, Pedido pedido)
        {
            var pedidoExistente = _dbContext.Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedidoExistente != null)
            {
                pedidoExistente.ClienteId = pedido.ClienteId;
                pedidoExistente.Data = pedido.Data;
                pedidoExistente.ValorTotal = pedido.ValorTotal;
                _dbContext.SaveChanges();
                return new { mensagem = "Pedido atualizado com sucesso" };
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }

        public object Delete(int id)
        {
            var pedidoExistente = _dbContext.Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedidoExistente != null)
            {
                _dbContext.Pedidos.Remove(pedidoExistente);
                _dbContext.SaveChanges();
                return new { mensagem = "Pedido removido com sucesso" };
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }

        public object GetByID(int id)
        {
            var pedido = _dbContext.Pedidos.Include(p => p.ClienteId).FirstOrDefault(p => p.Id == id);
            if (pedido != null)
            {
                return pedido;
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }
    }
}
