using Microsoft.EntityFrameworkCore;
using UserLogin.Models;


namespace EmailSendingServer;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=HONORBOOK\\SQLEXPRESS;Database=razorpagesdb;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
