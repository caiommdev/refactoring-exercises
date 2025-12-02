namespace Five;

public class EmailNotificationChannel : INotificationChannel
{
    public void Send(string message)
    {
        Console.WriteLine("Sending EMAIL: " + message);
    }
}

