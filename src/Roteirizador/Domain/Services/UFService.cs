using Roteirizador.Domain.Core.Notifications;
using Roteirizador.Domain.Core.Services;
using Roteirizador.Domain.Models;
using Roteirizador.Domain.Repositories;
using Roteirizador.Domain.Validators;

namespace Roteirizador.Domain.Services
{
    public class UFService : CRUDServiceBase<UF>, IUFService
    {
        public UFService(INotificator notifications,
            IUFValidator validator,
            IUFRepository ufRepository)
        : base(notifications, validator, ufRepository) { }
    }
}