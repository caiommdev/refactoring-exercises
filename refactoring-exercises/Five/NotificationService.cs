namespace Five;

public class NotificationService
{
    private readonly Dictionary<NotificationChannelType, INotificationChannel> _channels;

    public NotificationService()
    {
        _channels = new Dictionary<NotificationChannelType, INotificationChannel>
        {
            { NotificationChannelType.Email, new EmailNotificationChannel() },
            { NotificationChannelType.Sms, new SmsNotificationChannel() },
            { NotificationChannelType.Push, new PushNotificationChannel() }
        };
    }

    public void NotifyUser(NotificationChannelType channel, string message)
    {
        if (_channels.TryGetValue(channel, out var notificationChannel))
        {
            notificationChannel.Send(message);
        }
        else
        {
            throw new ArgumentException($"Unknown notification channel: {channel}");
        }
    }
}