using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Roteirizador.Domain.Core.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }
        public List<Notification> GetFailNotifications()
        {
            return _notifications.FindAll(n => n.Type == Notification.NotificationType.Fail);
        }
        public bool HasFailNotification()
        {
            return GetNotifications().Any(n => n.Type == Notification.NotificationType.Fail);
        }
        public Task Notify(Notification message, CancellationToken cancellationToken = default(CancellationToken))
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _notifications = new List<Notification>();
        }
    }
}