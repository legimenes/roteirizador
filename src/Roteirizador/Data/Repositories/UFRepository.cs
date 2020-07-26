using Roteirizador.Data.Context;
using Roteirizador.Domain.Core.Repositories;
using Roteirizador.Domain.Models;
using Roteirizador.Domain.Repositories;

namespace Roteirizador.Data.Repositories
{
    public class UFRepository : CRUDRepositoryBase<UF>, IUFRepository
    {
        public UFRepository(RouterDbContext context)
        : base(context)
        {
        }      
    }
}