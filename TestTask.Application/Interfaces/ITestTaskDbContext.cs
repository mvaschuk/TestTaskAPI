using Microsoft.EntityFrameworkCore;
using TestTask.Domain;

namespace TestTask.Application.Interfaces
{ 
    public interface ITestTaskDbContext
    {
        DbSet<Package> Packages { get; set; }
        DbSet<Recipient> Recipients { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}