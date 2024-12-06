using BlogApi.Data.Repositories.Contract;
using Domain.BlogDomain;
using BlogApi.Services.BlogService.Contract;


namespace BlogApi.Services.BlogService.Implementations;

public class BlogService : IBlogService
{

    private readonly IRepository<Blog> _repository;

    public BlogService(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public async Task<Blog> CreateBlog(Blog blog)
    {
        return await _repository.Add(blog);
    }

    public async Task<Blog> DeleteBlog(Blog blog)
    {
        return await _repository.Delete(blog);
    }

    public async Task<IEnumerable<Blog>> GetBlogs()
    {
        return await _repository.GetWithIncludes(includes: b => b.Comments);
    }

    public async Task<Blog> GetBlog(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Blog> UpdateBlog(Blog blog, Blog newBlog)
    {
        newBlog.UpdatedAt = DateTime.UtcNow;

        return await _repository.Update(blog, newBlog);
    }

    public async Task<Blog> GetBlogWithComments(int id)
    {
        return await _repository.GetEntityWithIncludes(b => b.Id == id, b => b.Comments);
    }

}
