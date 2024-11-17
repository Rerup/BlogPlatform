using System;
using BlogApi.Domain.BlogDomain;

namespace BlogApi.Services.BlogService.Contract;

public interface IBlogService
{
    Task<Blog> GetBlog(int id);

    Task<IEnumerable<Blog>> GetBlogs();

    void CreateBlog(Blog blog);

    void UpdateBlog(Blog bog, int id);

    void DeleteBlog(Blog blog);

    Task<IEnumerable<Blog>> GetBlogWithComments(int id);


}
