namespace SecureChat.Server.Database.Models;

public class Message
{
    public int Id { get; init; }
    public required string Content { get; init; }
    public required DateTime Created { get; init; }
    public int SenderId { get; init; }
    public User Sender { get; init; }
    public int ReceiverId { get; init; }
    public User Receiver { get; init; }
}