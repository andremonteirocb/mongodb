using System.Collections.Generic;

namespace Fundamentos.NoSQL.Models
{
    public class PublicacaoInputModel
    {
        public string Nome { get; set; }
        public string Description { get; set; }
        public List<string> Autores { get; set; }
    }

    public class ComentarioInputModel
    {
        public string Nome { get; set; }
        public string Conteudo { get; set; }
    }
}
