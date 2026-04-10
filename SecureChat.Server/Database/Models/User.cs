namespace SecureChat.Server.Database.Models;

public class User
{
    public int Id { get; init; }
    public required string Username { get; init; }
    public required string Password { get; set; }
    public required string PublicKey { get; init; }
}