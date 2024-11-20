using System;
using Domain.BlogDomain;

namespace BlogApi.Services.BlogService.Contract;

public interface IBlogService
{
    Task<Blog> GetBlog(int id);

    Task<IEnumerable<Blog>> GetBlogs();

    Task<Blog> CreateBlog(Blog blog);

    Task<Blog> UpdateBlog(Blog blog, Blog newBlog);

    Task<Blog> DeleteBlog(Blog blog);

    Task<IEnumerable<Blog>> GetBlogWithComments(int id);


}
