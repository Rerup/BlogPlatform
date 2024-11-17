
using BlogApi.Data;
using BlogApi.Data.Seeder;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlogApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("BlogPlatformDb"));
        });

        builder.Services.AddTransient<BlogDomainDataSeeder>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.MapControllers();

        app.UseAuthorization();

        using (var scope = app.Services.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetRequiredService<BlogDomainDataSeeder>();
            seeder.Seed();
        }

        app.Run();

    }
}
