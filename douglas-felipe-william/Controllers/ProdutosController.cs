using douglas_felipe_william.Contexto;
using douglas_felipe_william.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace douglas_felipe_william.Controllers
{
    public class ProdutosController
    {
        private readonly BancoDeDadosContexto _dbContext;

        public ProdutosController(BancoDeDadosContexto dbContext)
        {
            _dbContext = dbContext;
        }

        public object Get()
        {
            var produtos = _dbContext.Produtos.ToList();
            return produtos;
        }

        public object Post(Produto produto)
        {
            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();
            return new { mensagem = "Produto adicionado com sucesso" };
        }

        public object Put(int id, Produto produto)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(p => p.Id == id);
            if (produtoExistente != null)
            {
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.Marca = produto.Marca;
                produtoExistente.Preco = produto.Preco;
                _dbContext.SaveChanges();
                return new { mensagem = "Produto atualizado com sucesso" };
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }

        public object Delete(int id)
        {
            var produtoExistente = _dbContext.Produtos.FirstOrDefault(p => p.Id == id);
            if (produtoExistente != null)
            {
                _dbContext.Produtos.Remove(produtoExistente);
                _dbContext.SaveChanges();
                return new { mensagem = "Produto removido com sucesso" };
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }

        public object GetByID(int id)
        {
            var produto = _dbContext.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                return produto;
            }
            else
            {
                return new { erro = true, mensagem = "ID não encontrado" };
            }
        }
    }
}
