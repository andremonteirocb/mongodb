using MongoDB.Driver;
using System;
using System.Linq;
using Fundamentos.NoSQL.Domain.Interfaces;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Linq.Expressions;

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

        public List<T> QueryAll(int? limit = 0)
        {
            //return _collectionName.AsQueryable<T>();
            return _collectionName.Find(new BsonDocument()).Limit(limit).ToList();
        }

        public T Query(Expression<Func<T, bool>> expression)
        {
            var o = _collectionName.Find(expression).FirstOrDefault();
            //return _collectionName.AsQueryable<T>().FirstOrDefault(w => w.Id == key);
            return o;
        }

        public T GetById(Guid id)
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

        public void UpdatePartial(Guid id, UpdateDefinition<T> builder)
        {
            _collectionName.UpdateOne(a => a.Id == id, builder);
        }

        public void Delete(Guid id)
        {
            _collectionName.DeleteOne(a => a.Id == id);
        }
    }
}