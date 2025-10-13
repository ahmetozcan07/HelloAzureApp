using Microsoft.EntityFrameworkCore;
using MyCvMvcApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PhotoModel> Photos { get; set; }
}
