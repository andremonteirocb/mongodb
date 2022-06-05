using Fundamentos.NoSQL.Domain.Entities;
using System;

namespace Fundamentos.NoSQL.Domain.Interfaces
{
    public interface IPublicacaoServices : IRepository<Publicacao>
    {
        Comentario AdicionarComentario(Guid publicacaoId, string nome, string conteudo);
        void RemoverComentario(Guid publicacaoId, Guid comentarioId);
    }
}