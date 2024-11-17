using System;
using BlogApi.Domain.BlogDomain;

namespace BlogApi.Data.Seeder;

public class BlogDomainDataSeeder(ApplicationContext context) : IWillSeed
{

    private readonly ApplicationContext _context = context;

    public void Seed()
    {
        SeedBlogs();
    }

    private void SeedBlogs()
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

            _context.Blog.AddRange(blogs);
            _context.SaveChanges();
        }
    }
}
