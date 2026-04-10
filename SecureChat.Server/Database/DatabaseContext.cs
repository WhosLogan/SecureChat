using Microsoft.EntityFrameworkCore;
using SecureChat.Server.Database.Models;

namespace SecureChat.Server.Database;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
}