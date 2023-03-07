using TestTask.Application.Interfaces;

namespace TestTask.Persistance;

public class DbInitializer
{
    public static void Initialize(TestTaskDbContext context)
    {
        context.Database.EnsureCreated();
    }
}