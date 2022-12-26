using Microsoft.EntityFrameworkCore;

namespace BestCourse.Web.Models;

public class ApplicationDbContext:DbContext
{
    public DbSet<Currency> currency { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}