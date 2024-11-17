using System;
using BlogApi.Domain.BlogDomain;

namespace BlogApi.Data.Seeder;

public class BlogDomainDataSeeder
{

    private readonly ApplicationContext _context;

    public BlogDomainDataSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        SeedBlogs();
        SeedComments();
    }

    public void SeedBlogs()
    {
        if (!_context.Comments.Any())
        {

            var blogs = new List<Blog>
        {
            new Blog
            {
                Title = "First Blog",
                Content = "This is the first blog",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Blog
            {
                Title = "Second Blog",
                Content = "This is the second blog",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

            _context.Blog.AddRange(blogs);
            _context.SaveChanges();

        }
    }

    public void SeedComments()
    {
        if (!_context.Comments.Any())
        {
            var comments = new List<Comment>
            {
                new Comment
                {
                    BlogId = 1,
                    Content = "This is the first comment",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Comment
                {
                    BlogId = 1,
                    Content = "This is the second comment",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Comment
                {
                    BlogId = 2,
                    Content = "This is the third comment",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            _context.Comments.AddRange(comments);
            _context.SaveChanges();
        }
    }

}
