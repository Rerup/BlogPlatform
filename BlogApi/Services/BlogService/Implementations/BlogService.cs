using BlogApi.Data.Repositories.Contract;
using Domain.BlogDomain;
using BlogApi.Services.BlogService.Contract;
using Microsoft.EntityFrameworkCore;


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
        var query = _repository.Queryable();

        return await query.Include(b => b.Comments).ToListAsync();
    }

    public async Task<Blog> GetBlog(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<Blog> UpdateBlog(Blog blog, Blog newBlog)
    {
        return await _repository.Update(blog, newBlog);
    }

    public async Task<Blog> GetBlogWithComments(int id)
    {
        var query = _repository.Queryable();

        return await query.Where(b => b.Id == id).Include(b => b.Comments).FirstOrDefaultAsync();
    }

}
