using Microsoft.EntityFrameworkCore;
using MyCvMvcApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PhotoModel> Photos { get; set; }
    public DbSet<ContactFormModel> ContactForms { get; set; }
    public DbSet<BlogModel> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PhotoModel>().ToTable("Photos", "dbo");
    }
}
