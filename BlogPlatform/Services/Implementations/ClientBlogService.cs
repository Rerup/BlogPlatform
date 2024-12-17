using System;
using BlogPlatform.Services.Contracts;
using Domain.BlogDomain;

namespace BlogPlatform.Services;

public class ClientBlogService : IClientBlogService
{

    private readonly HttpClient _http;
    private readonly ILogger<ClientBlogService> _logger;

    public ClientBlogService(HttpClient http, ILogger<ClientBlogService> logger)
    {
        _http = http;
        _logger = logger;
    }

    public async Task PostBlogAsync(Blog blog)
    {
        var response = await _http.PostAsJsonAsync("blog", blog);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Failed to post blog id");

            throw new Exception("Failed to post blog");
        }
    }

    public async Task<Blog> GetBlogAsync(int id)
    {
        Blog blog = null;

        var response = await _http.GetAsync($"blog/{id}");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Failed to get blog id: {blogId}", id);

            throw new Exception("Failed to get blog");
        }

        blog = await response.Content.ReadFromJsonAsync<Blog>();

        return blog;
    }

    public async Task<IEnumerable<Blog>> GetBlogsAsync()
    {
        IEnumerable<Blog> blogs = [];

        var response = await _http.GetAsync("blog");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Failed to get blogs");

            throw new Exception("Failed to get blog");

        }

        blogs = await response.Content.ReadFromJsonAsync<IEnumerable<Blog>>();

        return blogs;
    }

    public async Task<Blog> UpdateBlogAsync(Blog blog)
    {
        var response = await _http.PutAsJsonAsync($"blog/{blog.Id}", blog);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to update blog");
        }

        blog = await response.Content.ReadFromJsonAsync<Blog>();

        return blog;

    }

    public async Task DeleteBlogAsync(int id)
    {
        var response = await _http.DeleteAsync($"blog/{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to delete blog");
        }
    }
}
