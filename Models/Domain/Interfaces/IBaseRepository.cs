using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_API.Domain.Interfaces
{
    public interface IBaseRepository<Entity> where Entity : class
    {
        Entity GetById(int entityId);
        IList<Entity> GetAll();
        void Save(Entity entity);
        bool Delete(int entityId);
        void Update(Entity entity);
    }
}