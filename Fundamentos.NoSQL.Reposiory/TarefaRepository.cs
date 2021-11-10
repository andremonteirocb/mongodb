using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;
using Fundamentos.NoSQL.Data.Base;

namespace Fundamentos.NoSQL.Data
{
    public sealed class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(IMongoDBConfig config)
            : base(config)
        {
        }
    }
}