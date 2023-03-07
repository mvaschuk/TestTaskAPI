using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestTask.Application.Interfaces;
using TestTask.Domain;
using TestTask.Persistance.Configurations;

namespace TestTask.Persistance;

public class TestTaskDbContext : DbContext, ITestTaskDbContext
{
    public DbSet<Package> Packages { get; set; }
    public DbSet<Recipient> Recipients { get; set; }

    public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PackageConfiguration());
        modelBuilder.ApplyConfiguration(new RecipientConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}