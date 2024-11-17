using BlogApi.Domain.BlogDomain;

namespace BlogApi.Data.Seeder;

public class CommentDomainDataSeeder(ApplicationContext context) : IWillSeed
{

    private readonly ApplicationContext _context = context;

    public void Seed()
    {
        SeedComments();
    }

    private void SeedComments()
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

            _context.Comments.AddRange(comments);
            _context.SaveChanges();
        }
    }

}
