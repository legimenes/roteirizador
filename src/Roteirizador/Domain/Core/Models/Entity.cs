namespace Roteirizador.Domain.Core.Models
{
    public class Entity
    {
        public long Id { get; private set; }

        protected Entity() { }
        protected Entity(long id)
        {
            Id = id;
        }
    }
}