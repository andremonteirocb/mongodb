using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;

namespace Fundamentos.NoSQL.Services
{
    public class ProdutoServices : BaseService<Produto>, IProdutoServices
    {
        public ProdutoServices(IProdutoRepository productRepository)
            : base(productRepository)
        {
        }
    }
}