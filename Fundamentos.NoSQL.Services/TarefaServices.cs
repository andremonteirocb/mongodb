using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;

namespace Fundamentos.NoSQL.Services
{
    public class TarefaServices : BaseService<Tarefa>, ITarefaServices
    {
        public TarefaServices(ITarefaRepository tarefaRepository)
            : base(tarefaRepository)
        {
        }
    }
}