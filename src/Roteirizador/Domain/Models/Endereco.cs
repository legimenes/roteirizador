using Roteirizador.Domain.Core.Models;

namespace Roteirizador.Domain.Models
{
    public class Endereco : Entity
    {
        protected Endereco() { }
        public Endereco(long id, string logradouro, string cep, long idBairro)
        : base(id)
        {
            Logradouro = logradouro;
            CEP = cep;
            IdBairro = idBairro;
        }

        public string Logradouro { get; private set; }
        public string CEP { get; private set; }
        public long IdBairro { get; private set; }
        public Bairro Bairro { get; private set; }
    }
}