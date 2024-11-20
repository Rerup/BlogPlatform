using System;
using Domain.BlogDomain;

namespace BlogPlatform.Services;

public class ClientBlogService
{

    private readonly HttpClient _http;

    public ClientBlogService(HttpClient http)
    {
        _http = http;
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
}
