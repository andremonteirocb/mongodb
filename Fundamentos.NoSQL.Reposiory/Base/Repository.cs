using MongoDB.Driver;
using System;
using System.Linq;
using Fundamentos.NoSQL.Domain.Interfaces;
using System.Collections.Generic;

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

        public List<T> QueryAll()
        {
            //return _collectionName.AsQueryable<T>();
            return _collectionName.Find(a => true).ToList();
        }

        public T Query(Guid id)
        {
            var o = _collectionName.Find(a => a.Id == id).FirstOrDefault();
            //return _collectionName.AsQueryable<T>().FirstOrDefault(w => w.Id == key);
            return o;
        }

        public void Insert(T obj)
        {
            _collectionName.InsertOne(obj);
        }

        public void Update(Guid id, T obj)
        {
            _collectionName.ReplaceOne(a => a.Id == id, obj);
        }

        public void Delete(Guid id)
        {
            _collectionName.DeleteOne(a => a.Id == id);
        }
    }
}