using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;

namespace Fundamentos.NoSQL.Services
{
    public class PublicacaoServices : BaseService<Publicacao>, IPublicacaoServices
    {
        public PublicacaoServices(IPublicacaoRepository publicacaoRepository)
            : base(publicacaoRepository)
        {
        }
    }
}