using Fundamentos.NoSQL.Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        public List<T> QueryAll()
        {
            return _repository.QueryAll();
        }

        public T Query(Guid id)
        {
            return _repository.Query(id);
        }

        public void Insert(T obj)
        {
            _repository.Insert(obj);
        }

        public void Update(Guid id, T obj)
        {
            _repository.Update(id, obj);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}