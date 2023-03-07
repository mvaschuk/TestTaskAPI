using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Application;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Interfaces;
using TestTask.Persistance;

namespace TestTaskAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ITestTaskDbContext).Assembly));
            });
            builder.Services.AddApplication();
            builder.Services.AddPersistance(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    DbInitializer.Initialize(serviceProvider.GetRequiredService<TestTaskDbContext>());
                }
                catch (Exception e)
                {

                }
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}