using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Application.Interfaces;

namespace TestTask.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TestTaskDbContext>(options => options.UseSqlite(configuration["DbConnection"]));
        services.AddScoped<ITestTaskDbContext>(provider => provider.GetService<TestTaskDbContext>());
        return services;
    }
}