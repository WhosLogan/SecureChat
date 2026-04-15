using System.ComponentModel.DataAnnotations;

namespace SecureChat.Server.Database.Models;

public class Session
{
    public int Id { get; init; }
    
    [StringLength(32)]
    public required string Secret { get; init; }
    
    public DateTime Expiration { get; set; }
    
    public int UserId { get; init; }
    public User? User { get; init; }
}