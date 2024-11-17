using BlogApi.Data.Repositories.Contract;
using BlogApi.Domain.BlogDomain;
using BlogApi.Services.BlogService.Contract;


namespace BlogApi.Services.BlogService.Implementations;

public class BlogService : IBlogService
{

    private readonly IRepository<Blog> _repository;

    public BlogService(IRepository<Blog> repository)
    {
        _repository = repository;
    }

    public void CreateBlog(Blog blog)
    {
        _repository.Add(blog);
    }

    public void DeleteBlog(Blog blog)
    {
        _repository.Delete(blog);
    }

    public async Task<IEnumerable<Blog>> GetBlogs()
    {
        return await _repository.GetAll();
    }

    public async Task<Blog> GetBlog(int id)
    {
        return await _repository.GetById(id);
    }

    public void UpdateBlog(Blog blog, int id)
    {
        _repository.Update(blog);
    }

    public async Task<IEnumerable<Blog>> GetBlogWithComments(int id)
    {
        return await _repository.GetWithIncludes(b => b.Id == id, b => b.Comments);
    }

}
