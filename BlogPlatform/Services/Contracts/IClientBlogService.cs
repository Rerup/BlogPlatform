using System;
using Domain.BlogDomain;

namespace BlogPlatform.Services.Contracts;

public interface IClientBlogService
{
    Task PostBlogAsync(Blog blog);
    Task<Blog> GetBlogAsync(int id);
    Task<IEnumerable<Blog>> GetBlogsAsync();
    Task<Blog> UpdateBlogAsync(Blog blog);
    Task DeleteBlogAsync(int id);
}
