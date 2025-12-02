namespace Five;

public class SmsNotificationChannel : INotificationChannel
{
    public void Send(string message)
    {
        Console.WriteLine("Sending SMS: " + message);
    }
}

