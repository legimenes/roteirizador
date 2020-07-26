using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roteirizador.Data.Context;
using Roteirizador.Domain.Core.Models;

namespace Roteirizador.Domain.Core.Repositories
{
    public abstract class CRUDRepositoryBase<T> : RepositoryBase, ICRUDRepository<T>
        where T : Entity
    {
        protected DbSet<T> _dbSet;

        protected CRUDRepositoryBase(RouterDbContext context) : base(context)
        {
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T> Inserir(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public virtual async Task<T> Alterar(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
        public virtual async Task<bool> Deletar(long id)
        {
            T entity = await Obter(id);

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<T> Obter(long id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task<IEnumerable<T>> Obter(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        // public virtual async Task<IEnumerable<T>> GetWithRawSql(string query, params object[] parameters)
        // {
        //     return await _dbSet.SqlQuery(query, parameters).ToList();
        // }
    }
}