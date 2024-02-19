using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class PeopleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public PeopleContext(DbContextOptions options) : base(options)
    {
        
    }
}