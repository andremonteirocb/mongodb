using System;
using Fundamentos.NoSQL.Domain.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace Fundamentos.NoSQL.Domain.Base
{
    public abstract class Entity : IEntity
    {
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}