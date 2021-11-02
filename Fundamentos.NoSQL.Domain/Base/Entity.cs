using System;
using Fundamentos.NoSQL.Domain.Interfaces;

namespace Fundamentos.NoSQL.Domain.Base
{
    public abstract class Entity : IEntity
    {
        public Guid Key { get; set; }

        protected Entity()
        {
            this.Key = Guid.NewGuid();
        }
    }
}