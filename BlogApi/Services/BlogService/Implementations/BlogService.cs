using BlogApi.Data.Repositories.Contract;
using Domain.BlogDomain;
using BlogApi.Services.BlogService.Contract;
using Microsoft.EntityFrameworkCore;


namespace BlogApi.Services.BlogService.Implementations;

public class BlogService : IBlogService
{

    private readonly IRepository<Blog> _repository;
    private readonly ILogger<BlogService> _logger;

    public BlogService(IRepository<Blog> repository, ILogger<BlogService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Blog> CreateBlog(Blog blog)
    {
        _logger.LogInformation("Creating a new blog");

        return await _repository.Add(blog);
    }

    public async Task<Blog> DeleteBlog(Blog blog)
    {
        _logger.LogInformation($"Deleting a blog with id: {blog.Id} ");

        return await _repository.Delete(blog);
    }

    public async Task<IEnumerable<Blog>> GetBlogs()
    {
        var query = _repository.Queryable();

        _logger.LogInformation("Getting all blogs");

        return await query.Include(b => b.Comments).ToListAsync();
    }

    public async Task<Blog> GetBlog(int id)
    {
        _logger.LogInformation($"Getting a blog with id: {id}");

        return await _repository.GetById(id);
    }

    public async Task<Blog> UpdateBlog(Blog blog, Blog newBlog)
    {
        _logger.LogInformation($"Updating a blog with id: {blog.Id}");

        return await _repository.Update(blog, newBlog);
    }

    public async Task<Blog> GetBlogWithComments(int id)
    {
        var query = _repository.Queryable();

        return await query.Where(b => b.Id == id).Include(b => b.Comments).FirstOrDefaultAsync();
    }

}
