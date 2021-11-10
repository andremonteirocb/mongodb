using MongoDB.Bson.Serialization.Attributes;
using Fundamentos.NoSQL.Domain.Base;
using System;

namespace Fundamentos.NoSQL.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public sealed class Produto : Entity
    {
        public Produto(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public void AtualizarProduto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}