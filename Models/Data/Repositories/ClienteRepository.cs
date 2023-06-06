using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_API.Domain.Entities;
using Projeto_API.Domain.Interfaces;

namespace Projeto_API.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext context;
        public ClienteRepository()
        {
            this.context = new DataContext();
        }

        public Cliente GetById(int entityId)
        {
            return context.Clientes.SingleOrDefault(x => x.Id == entityId);
        }

        public IList<Cliente> GetAll()
        {
            return context.Clientes.ToList();
        }

        public void Save(Cliente entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int entityId)
        {
            var cliente = GetById(entityId);
            context.Remove(cliente);
            context.SaveChanges();
            return true;
        }

        public void Update(Cliente entity)
        {
            context.Clientes.Update(entity);
            context.SaveChanges();
        }
    }
}