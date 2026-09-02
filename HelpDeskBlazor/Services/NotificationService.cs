using System;
using System.Collections.Generic;

namespace HelpDeskBlazor.Services
{
    public class NotificationService
    {
        public List<Notification> Notifications { get; private set; } = new();

        public event Action? OnNotificationsChanged;

        public void AddNotification(string title, string message, string type = "info")
        {
            var notification = new Notification
            {
                Title = title,
                Message = message,
                Time = DateTime.Now.ToString("hh:mm tt"),
                Type = type
            };
            Notifications.Insert(0, notification);
            OnNotificationsChanged?.Invoke();
        }

        public void ClearAll()
        {
            Notifications.Clear();
            OnNotificationsChanged?.Invoke();
        }
    }

    public class Notification
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string Time { get; set; } = "";
        public string Type { get; set; } = "info";
    }
}