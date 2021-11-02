using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;
using Fundamentos.NoSQL.Data.Base;

namespace Fundamentos.NoSQL.Data
{
    public sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDBConfig config) 
            : base(config)
        {
        }
    }
}