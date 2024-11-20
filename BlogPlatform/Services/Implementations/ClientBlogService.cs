using System;
using BlogPlatform.Services.Contracts;
using Domain.BlogDomain;

namespace BlogPlatform.Services;

public class ClientBlogService : IClientBlogService
{

    private readonly HttpClient _http;

    public ClientBlogService(HttpClient http)
    {
        _http = http;
    }

    public async Task PostBlogAsync(Blog blog)
    {
        var response = await _http.PostAsJsonAsync("blog", blog);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to post blog");
        }
    }

    public async Task<Blog> GetBlogAsync(int id)
    {
        Blog blog = null;

        var response = await _http.GetAsync($"blog/{id}");

        if (response.IsSuccessStatusCode)
        {
            blog = await response.Content.ReadFromJsonAsync<Blog>();

            return blog;
        }

        return blog;
    }

    public async Task<IEnumerable<Blog>> GetBlogsAsync()
    {
        IEnumerable<Blog> blogs = [];

        var response = await _http.GetAsync("blog");

        if (response.IsSuccessStatusCode)
        {

            blogs = await response.Content.ReadFromJsonAsync<IEnumerable<Blog>>();

            return blogs;
        }

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
