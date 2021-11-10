using Fundamentos.NoSQL.Domain.Base;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Fundamentos.NoSQL.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class Tarefa : Entity
    {
        public Tarefa(string nome, string detalhes)
        {
            Nome = nome;
            Detalhes = detalhes;
            Concluido = false;
            DataCadastro = DateTime.Now;
            DataConclusao = null;
        }

        public string Nome { get; private set; }
        public string Detalhes { get; private set; }
        public bool Concluido { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataConclusao { get; private set; }


        public void AtualizarTarefa(string nome, string detalhes, bool? concluido = false)
        {
            Nome = nome;
            Detalhes = detalhes;
            Concluido = concluido ?? false;

            if (Concluido)
                DataConclusao = DateTime.Now;
        }
    }
}
