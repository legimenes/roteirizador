using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roteirizador.Domain.Core.Notifications;

namespace Roteirizador.Domain.Core.Services
{
    public abstract class ServiceBase
    {
        private readonly INotificator _notifications;

        protected ServiceBase(INotificator notifications)
        {
            _notifications = notifications;
        }

        protected async Task Notify(Exception exception)
        {
            await _notifications.Notify(new Notification(exception));
        }
        protected async Task Notify(string notification)
        {
            await  _notifications.Notify(new Notification(Notification.NotificationType.Fail, notification));
        }
        protected async Task Notify(List<string> notifications)
        {
            foreach (var notification in notifications)
                await  _notifications.Notify(new Notification(Notification.NotificationType.Fail, notification));
        }
    }
}