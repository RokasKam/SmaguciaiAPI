using Microsoft.EntityFrameworkCore;

namespace SmaguciaiInfrastructure.Data;

public class SmaguciaiDataContext : DbContext
{
    public SmaguciaiDataContext(DbContextOptions<SmaguciaiDataContext> options) : base(options)
    {
    }

    // Define your entities here
    //public DbSet<YourEntity> YourEntities { get; set; }
}