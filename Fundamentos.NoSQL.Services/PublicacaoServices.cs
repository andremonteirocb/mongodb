using Fundamentos.NoSQL.Domain.Entities;
using Fundamentos.NoSQL.Domain.Interfaces;
using System;

namespace Fundamentos.NoSQL.Services
{
    public class PublicacaoServices : BaseService<Publicacao>, IPublicacaoServices
    {
        public PublicacaoServices(IPublicacaoRepository publicacaoRepository)
            : base(publicacaoRepository)
        {
        }

        public Comentario AdicionarComentario(Guid publicacaoId, string nome, string conteudo)
        {
            var comentario = new Comentario(Guid.NewGuid(), nome, conteudo, DateTime.Now);
            base.Push(condition => condition.Id == publicacaoId, 
                o => o.Comentarios, comentario);

            return comentario;
        }

        public void RemoverComentario(Guid publicacaoId, Guid comentarioId)
        {
            base.Pull<Comentario>(condition => condition.Id == publicacaoId,
                comentarios => comentarios.Comentarios,
                comentario => comentario.Id == comentarioId);
        }
    }
}