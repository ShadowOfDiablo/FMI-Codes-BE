using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class FmiDatabaseConfig : DbContext
{
    public FmiDatabaseConfig(DbContextOptions<FmiDatabaseConfig> options) : base(options)
    {
        
    }

    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<User> Users { get; set; }
}