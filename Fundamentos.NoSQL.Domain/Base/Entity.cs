using System;
using Fundamentos.NoSQL.Domain.Interfaces;

namespace Fundamentos.NoSQL.Domain.Base
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}