using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_API.Domain.Entities
{
    public class ProdutoVenda
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public double ProdutoPreco { get; set; }
        [NotMapped] public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ProdutoVenda() { }
        public ProdutoVenda(Produto produto, int quantidade)
        {
            Produto = produto;
            ProdutoId = produto.Id;
            Quantidade = quantidade;
            ProdutoPreco = produto.Preco;
            Produto.Estoque = Produto.Estoque - quantidade;
        }
    }
}