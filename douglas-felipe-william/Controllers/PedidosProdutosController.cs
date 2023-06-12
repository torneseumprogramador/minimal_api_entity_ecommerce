using douglas_felipe_william.Contexto;
using douglas_felipe_william.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace douglas_felipe_william.Controllers
{
    public class PedidoProdutosController
    {
        private readonly BancoDeDadosContexto _dbContext;

        public PedidoProdutosController(BancoDeDadosContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public object Get(int pedidoId)
        {
            var pedidoProdutos = _dbContext.PedidosProdutos.Include(pp => pp.ProdutoId).Where(pp => pp.PedidoId == pedidoId).ToList();
            return pedidoProdutos;
        }

        public object Post(int pedidoId, PedidoProduto pedidoProduto)
        {
            pedidoProduto.PedidoId = pedidoId;
            _dbContext.PedidosProdutos.Add(pedidoProduto);
            _dbContext.SaveChanges();
            return new { mensagem = "PedidoProduto adicionado com sucesso" };
        }

        public object Put(int pedidoId, int id, PedidoProduto pedidoProduto)
        {
            var pedidoProdutoExistente = _dbContext.PedidosProdutos.FirstOrDefault(pp => pp.PedidoId == pedidoId && pp.Id == id);
            if (pedidoProdutoExistente != null)
            {
                pedidoProdutoExistente.ProdutoId = pedidoProduto.ProdutoId;
                pedidoProdutoExistente.Quantidade = pedidoProduto.Quantidade;
                pedidoProdutoExistente.ValorItem = pedidoProduto.ValorItem;
                _dbContext.SaveChanges();
                return new { mensagem = "PedidoProduto atualizado com sucesso" };
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }

        public object Delete(int pedidoId, int id)
        {
            var pedidoProdutoExistente = _dbContext.PedidosProdutos.FirstOrDefault(pp => pp.PedidoId == pedidoId && pp.Id == id);
            if (pedidoProdutoExistente != null)
            {
                _dbContext.PedidosProdutos.Remove(pedidoProdutoExistente);
                _dbContext.SaveChanges();
                return new { mensagem = "PedidoProduto removido com sucesso" };
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }
    }
}
