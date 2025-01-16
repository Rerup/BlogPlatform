using BlogApi.Data;
using BlogApi.Data.Repositories.Contract;
using BlogApi.Data.Repositories.Implementations;
using BlogApi.Services.BlogService.Contract;
using BlogApi.Services.BlogService.Implementations;
using BlogApi.Services.CommentService.Contract;
using BlogApi.Services.CommentService.Implementations;
using Microsoft.AspNetCore.Mvc;
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
        builder.Logging.AddConsole();

        builder.Services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("BlogPlatformDb"));
        });

        builder.Services.AddTransient(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
        builder.Services.AddTransient<IBlogService, BlogService>();
        builder.Services.AddTransient<ICommentService, CommentService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseApiVersioning();
        app.MapControllers();

        app.Run();

    }
}
