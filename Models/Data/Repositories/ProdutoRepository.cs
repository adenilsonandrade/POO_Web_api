using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_API.Domain.Entities;
using Projeto_API.Domain.Interfaces;

namespace Projeto_API.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext context;
        public ProdutoRepository()
        {
            this.context = new DataContext();
        }

        public Produto GetById(int entityId)
        {
            return context.Produtos.SingleOrDefault(x => x.Id == entityId);
        }

        public IList<Produto> GetAll()
        {
            return context.Produtos.ToList();
        }

        public void Save(Produto entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int entityId)
        {
            var produto = GetById(entityId);
            context.Remove(produto);
            context.SaveChanges();
            return true;
        }

        public void Update(Produto entity)
        {
            context.Produtos.Update(entity);
            context.SaveChanges();
        }
    }
}