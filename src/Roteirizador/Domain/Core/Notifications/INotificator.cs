using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Roteirizador.Domain.Core.Notifications
{
    public interface INotificator : IDisposable
    {
        List<Notification> GetNotifications();
        List<Notification> GetFailNotifications();
        bool HasFailNotification();
        Task Notify(Notification message, CancellationToken cancellationToken = default(CancellationToken));
    }
}