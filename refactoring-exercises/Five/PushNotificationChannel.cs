namespace Five;

public class PushNotificationChannel : INotificationChannel
{
    public void Send(string message)
    {
        Console.WriteLine("Sending PUSH: " + message);
    }
}

