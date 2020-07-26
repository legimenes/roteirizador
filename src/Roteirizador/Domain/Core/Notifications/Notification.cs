using System;

namespace Roteirizador.Domain.Core.Notifications
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime DateOccurred { get; private set; }
        public string Value { get; private set; }
        public Exception Exception { get; private set; }

        public enum NotificationType
        {
            Fail = 0,
            Success = 1,
            Information = 2
        }

        public Notification(NotificationType type, string value)
        {
            Id = Guid.NewGuid();
            Type = type;
            DateOccurred = DateTime.UtcNow;
            Value = value;
        }
        public Notification(Exception exception)
        {
            Id = Guid.NewGuid();
            Type = NotificationType.Fail;
            DateOccurred = DateTime.UtcNow;
            Value = exception.Message;
            Exception = exception;
        }
    }
}