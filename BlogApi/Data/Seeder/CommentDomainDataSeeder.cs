using BlogApi.Domain.BlogDomain;

namespace BlogApi.Data.Seeder;

public class CommentDomainDataSeeder : IWillSeed
{

    private readonly ApplicationContext _context;

    public CommentDomainDataSeeder(ApplicationContext context)
    {
        _context = context;
    }

    public async void Seed()
    {
        await SeedComments();
    }

    private async Task SeedComments()
    {
        if (!_context.Comments.Any())
        {
            int numberOfComments = 3;
            var comments = new List<Comment>();

            var blogs = _context.Blog.ToList();

            for (int i = 1; i <= numberOfComments; i++)
            {
                comments.Add(new Comment
                {
                    BlogId = blogs[i].Id,
                    Content = $"This is comment number {i}",
                });
            }

            await _context.Comments.AddRangeAsync(comments);
            await _context.SaveChangesAsync();
        }
    }

}
