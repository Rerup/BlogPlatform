using System;
using BlogPlatform.Services.Contracts;
using Domain.BlogDomain;

namespace BlogPlatform.Services;

public class ClientCommentService : IClientCommentService
{
    private readonly HttpClient _httpClient;

    public ClientCommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        var response = await _httpClient.PostAsJsonAsync("comment", comment);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to add comment");
        }

        return await response.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task DeleteCommentAsync(int commentId)
    {
        var response = await _httpClient.DeleteAsync($"comment/{commentId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to delete comment");
        }
    }

}
