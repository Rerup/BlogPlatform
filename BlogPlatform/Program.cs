using BlogPlatform.Components;
using BlogPlatform.Services;

namespace BlogPlatform;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents();
        builder.Services.AddHttpClient();
        builder.Services.AddTransient<ClientBlogService>();

        builder.Services.AddScoped(sp =>
        new HttpClient
        {
            BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "http://localhost:5064/api/v1")
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>();

        app.Run();
    }
}
