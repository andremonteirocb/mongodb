using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Fundamentos.NoSQL.Domain.Interfaces
{
    public interface IBaseService<T> where T : IEntity
    {
        List<T> QueryAll(int? limit = 0);
        T Query(Expression<Func<T, bool>> expression);
        T GetById(Guid id);
        void Insert(T obj);
        void Delete(Guid id);
    }
}
