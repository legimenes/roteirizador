using Roteirizador.Domain.Core.Models;

namespace Roteirizador.Domain.Models
{
    public class Bairro : Entity
    {
        protected Bairro() { }
        public Bairro(long id, string nome, long idCidade)
        : base(id)
        {
            Nome = nome;
            IdCidade = idCidade;
        }

        public string Nome { get; private set; }
        public long IdCidade { get; private set; }
        public Cidade Cidade { get; private set; }
    }
}