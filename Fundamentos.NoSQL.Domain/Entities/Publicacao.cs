using MongoDB.Bson.Serialization.Attributes;
using Fundamentos.NoSQL.Domain.Base;
using System;
using System.Collections.Generic;

namespace Fundamentos.NoSQL.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public sealed class Publicacao : Entity
    {
        public Publicacao(string name, string description)
        {
            Name = name;
            Description = description;

            Autores = new List<Autor>();
            Comentarios = new List<Comentario>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Autor> Autores { get; set; }
        public List<Comentario> Comentarios { get; set; }

        public void AtualizarPublicacao(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AdicionarAutor(string name)
        {
            Autores.Add(new Autor(name));
        }

        public void AdicionarComentario(string name, string conteudo)
        {
            Comentarios.Add(new Comentario(Guid.NewGuid(), name, conteudo, DateTime.Now));
        }
    }

    public class Autor
    {
        public Autor(Guid id)
        {
            Id = id;
        }

        public Autor(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
    }

    public class Comentario
    {
        public Comentario(Guid id, string name, string conteudo, DateTime dataCriacao)
        {
            Id = id;
            Name = name;
            Conteudo = conteudo;
            DataCriacao = dataCriacao;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Conteudo { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}