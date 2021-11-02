using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;

namespace Fundamentos.NoSQL.Services
{
    public class ProductServices : BaseService<Product>, IProductServices
    {
        public ProductServices(IProductRepository productRepository)
            : base(productRepository)
        {
        }
    }
}