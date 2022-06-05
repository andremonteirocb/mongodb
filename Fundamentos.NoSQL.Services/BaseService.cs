using Fundamentos.NoSQL.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Fundamentos.NoSQL.Services
{
    public class BaseService<T> : IBaseService<T> where T : IEntity
    {
        private readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public List<T> QueryAll(int? limit = 0)
        {
            return _repository.QueryAll(limit);
        }

        public T Query(Expression<Func<T, bool>> expression)
        {
            return _repository.Query(expression);
        }

        public T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Insert(T obj)
        {
            _repository.Insert(obj);
        }

        public void Replace(Guid id, T obj)
        {
            _repository.Replace(id, obj);
        }

        public void Update(Expression<Func<T, bool>> condicao, Expression<Func<T, object>> expression, object value)
        {
            _repository.Update(condicao, expression, value);
        }

        public void Push(Expression<Func<T, bool>> condicao, Expression<Func<T, IEnumerable<object>>> expression, object value)
        {
            _repository.Push(condicao, expression, value);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}