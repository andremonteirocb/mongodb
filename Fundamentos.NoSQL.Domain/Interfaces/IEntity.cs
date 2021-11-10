using System;

namespace Fundamentos.NoSQL.Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}