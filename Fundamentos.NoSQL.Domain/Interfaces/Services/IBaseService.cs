using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentos.NoSQL.Domain.Interfaces
{
    public interface IBaseService<T> where T : IEntity
    {
        List<T> QueryAll();
        T Query(Guid id);
        void Insert(T obj);
        void Delete(Guid id);
    }
}
