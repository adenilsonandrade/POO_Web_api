using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_API.Domain.Entities;
using Projeto_API.Domain.Interfaces;

namespace Projeto_API.Data.Repositories
{
    public class ProdutoVendaRepository : IProdutoVendaRepository
    {
        private readonly DataContext context;
        public ProdutoVendaRepository(DataContext context)
        {
            this.context = context;
        }

        public ProdutoVenda GetById(int entityId)
        {
            return context.ProdutosVendas.SingleOrDefault(x => x.Id == entityId);
        }

        public IList<ProdutoVenda> GetAll()
        {
            return context.ProdutosVendas.ToList();
        }

        public void Save(ProdutoVenda entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int entityId)
        {
            var venda = GetById(entityId);
            context.Remove(venda);
            context.SaveChanges();
            return true;
        }

        public void Update(ProdutoVenda entity)
        {
            context.ProdutosVendas.Update(entity);
            context.SaveChanges();
        }
    }
}