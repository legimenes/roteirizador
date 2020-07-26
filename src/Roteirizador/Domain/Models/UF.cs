using Roteirizador.Domain.Core.Models;

namespace Roteirizador.Domain.Models
{
    public class UF : Entity
    {
        protected UF() { }
        public UF(long id, string sigla, string nome)
        : base(id)
        {
            Sigla = sigla;
            Nome = nome;
        }
        
        public string Sigla { get; private set; }
        public string Nome { get; private set; }
    }
}