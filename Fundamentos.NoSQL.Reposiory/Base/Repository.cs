using MongoDB.Driver;
using System;
using System.Linq;
using Fundamentos.NoSQL.Domain.Interfaces;

namespace Fundamentos.NoSQL.Data.Base
{
    public abstract class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collectionName;
        protected Repository(IMongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            var dataBase = client.GetDatabase(config.Database);
            _collectionName = dataBase.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<T> QueryAll()
        {
            return _collectionName.AsQueryable<T>();
        }

        public T Query(Guid key)
        {
            return _collectionName.AsQueryable<T>().FirstOrDefault(w => w.Key == key);
        }

        public void Insert(T obj)
        {
            _collectionName.InsertOne(obj);
        }

        public void Delete(Guid id)
        {
            _collectionName.DeleteOne(a => a.Key == id);
        }
    }
}