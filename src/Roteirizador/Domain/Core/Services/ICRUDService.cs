using System.Threading.Tasks;
using Roteirizador.Domain.Core.Models;
using Roteirizador.Domain.Models;

namespace Roteirizador.Domain.Core.Services
{
    public interface ICRUDService<T> where T : Entity
    {
        Task<T> Salvar(T entity);
        Task<bool> Excluir(long id);
    }
}