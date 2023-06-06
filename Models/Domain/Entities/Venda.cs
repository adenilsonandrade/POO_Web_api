using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Projeto_API.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<ProdutoVenda> Produtos { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public double Total { get; set; }

        public Venda() { }

        public Venda(Cliente cliente)
        {
            ClienteId = cliente.Id;
            Produtos = new List<ProdutoVenda>();
        }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if (produto.Estoque >= quantidade)
            {
                var produtoVenda = new ProdutoVenda(produto, quantidade);
                Produtos.Add(produtoVenda);
                produto.Estoque -= quantidade;
            }
            else
            {
                throw new Exception("Estoque insuficiente para adicionar o produto à venda.");
            }
        }

        public void EfetuarVenda()
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            Total = Produtos.Sum(produtoVenda => produtoVenda.Produto.Preco * produtoVenda.Quantidade);
        }
    }
}