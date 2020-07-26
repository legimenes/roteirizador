using Roteirizador.Domain.Core.Models;

namespace Roteirizador.Domain.Models
{
    public class Cidade : Entity
    {
        protected Cidade() { }
        public Cidade(long id, string nome, long idUF)
        : base(id)
        {
            Nome = nome;
            IdUF = idUF;
        }

        public string Nome { get; private set; }
        public long IdUF { get; private set; }
        public UF UF { get; private set; }
    }
}