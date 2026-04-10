using System.Text;
using WatsonTcp;

namespace SecureChat.Client;

internal static class Program
{
    internal static async Task Main(string[] args)
    {
        var client = new WatsonTcpClient("127.0.0.1", 9000);
        client.Events.MessageReceived += OnMessageReceived;
        client.Connect();
        var success = await client.SendAsync(Encoding.Unicode.GetBytes("Hello World!"));
        client.Disconnect();
    }

    private static void OnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        Console.WriteLine("Received message on client");
    }
}