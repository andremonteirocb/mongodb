using Fundamentos.NoSQL.Domain.Interfaces;
using System;
using System.Linq;

namespace Fundamentos.NoSQL.Services
{
    public class BaseService<T> : IBaseService<T> where T : IEntity
    {
        private readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IQueryable<T> QueryAll()
        {
            return _repository.QueryAll();
        }

        public T Query(Guid key)
        {
            return _repository.Query(key);
        }

        public void Insert(T obj)
        {
            _repository.Insert(obj);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}