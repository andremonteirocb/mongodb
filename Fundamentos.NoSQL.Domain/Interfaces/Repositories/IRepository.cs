using System;
using System.Linq;

namespace Fundamentos.NoSQL.Domain.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> QueryAll();
        T Query(Guid key);
        void Insert(T obj);
        void Delete(Guid id);
    }
}