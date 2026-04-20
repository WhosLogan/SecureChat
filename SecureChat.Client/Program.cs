using System.Text;
using SecureChat.Shared.Cryptography.Rsa;
using WatsonTcp;

namespace SecureChat.Client;

internal static class Program
{
    internal static async Task Main(string[] args)
    {
        // Make sure we have our public and private key generated
        var usrDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var clientPrivate = new PrivateKey(Path.Combine(usrDir, ".scpriv"));
        
        // Ask for username and password
        Console.Write($"Username: ");
        var username = Console.ReadLine();
        
        Console.Write($"Password: ");
        var password = Console.ReadLine();
        
        // Initialize connection to server
        var client = new WatsonTcpClient("127.0.0.1", 9000);
        client.Events.MessageReceived += OnMessageReceived;
        client.Events.ServerConnected += OnServerConnected;
        client.Connect();
        
        // Send credentials to become authenticated
    }

    private static void OnServerConnected(object? sender, ConnectionEventArgs e)
    {
        throw new NotImplementedException();
    }

    private static void OnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        throw new NotImplementedException();
    }
}