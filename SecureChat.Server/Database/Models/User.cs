using System.ComponentModel.DataAnnotations;

namespace SecureChat.Server.Database.Models;

public class User
{
    public int Id { get; init; }
    
    [StringLength(50)]
    public required string Username { get; init; }
    
    //TODO: Find teh actual string length of the two below fields
    [StringLength(50)]
    public required string Password { get; set; }
    
    [StringLength(1000)]
    public required string PublicKey { get; init; }
}