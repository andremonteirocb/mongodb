using MongoDB.Bson.Serialization.Attributes;
using Fundamentos.NoSQL.Domain.Base;

namespace Fundamentos.NoSQL.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public sealed class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}