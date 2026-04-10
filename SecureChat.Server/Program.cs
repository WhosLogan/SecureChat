using System.Text;
using WatsonTcp;

namespace SecureChat.Server;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var server = new WatsonTcpServer("127.0.0.1", 9000);
        server.Events.ClientConnected += OnClientConnected;
        server.Events.MessageReceived += OnMessageReceived;
        server.Start();

        var resetEvent = new ManualResetEvent(false);
        Console.CancelKeyPress += (_, _) =>
        {
            server.Stop();
            resetEvent.Set();
        };

        resetEvent.WaitOne();
    }

    private static void OnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        Console.WriteLine(Encoding.Unicode.GetString(e.Data));
    }

    private static void OnClientConnected(object? sender, ConnectionEventArgs e)
    {
        Console.WriteLine($"New client connected: {e.Client.IpPort}");
    }
}