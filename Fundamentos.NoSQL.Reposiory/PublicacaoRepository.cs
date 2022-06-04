using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;
using Fundamentos.NoSQL.Data.Base;

namespace Fundamentos.NoSQL.Data
{
    public sealed class PublicacaoRepository : Repository<Publicacao>, IPublicacaoRepository
    {
        public PublicacaoRepository(IMongoDBConfig config) 
            : base(config)
        {
        }
    }
}