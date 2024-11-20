using System;
using Domain.BlogDomain;

namespace BlogApi.Data.Seeder;

public class BlogDomainDataSeeder : IWillSeed
{

    private readonly ApplicationContext _context;

    public BlogDomainDataSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public async void Seed()
    {
        await SeedBlogs();
    }

    private async Task SeedBlogs()
    {
        if (!_context.Blog.Any())
        {
            int numberOfBlogs = 5;

            var blogs = new List<Blog>();

            for (int i = 1; i <= numberOfBlogs; i++)
            {
                blogs.Add(new Blog
                {
                    Title = $"Blog {i}",
                    Content = $"This is blog number {i}",
                });
            }

            await _context.Blog.AddRangeAsync(blogs);

            await _context.SaveChangesAsync();
        }
    }
}
