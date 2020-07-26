using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Roteirizador.Domain.Core.Models;

namespace Roteirizador.Domain.Core.Repositories
{
    public interface ICRUDRepository<T> : IRepository
        where T : Entity
    {
        Task<T> Inserir(T entity);
        Task<T> Alterar(T entity);
        Task<bool> Deletar(long id);
        Task<T> Obter(long id);
        Task<IEnumerable<T>> Obter(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
    }
}