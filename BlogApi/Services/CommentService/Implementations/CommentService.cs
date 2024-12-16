using System;
using BlogApi.Data.Repositories.Contract;
using BlogApi.Services.CommentService.Contract;
using Domain.BlogDomain;

namespace BlogApi.Services.CommentService.Implementations;

public class CommentService : ICommentService
{
    private readonly IRepository<Comment> _commentRepository;

    public CommentService(IRepository<Comment> commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<Comment> GetComment(int id)
    {
        return await _commentRepository.GetById(id);
    }

    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        return await _commentRepository.Add(comment);
    }

    public async Task<Comment> DeleteCommentAsync(Comment comment)
    {
        return await _commentRepository.Delete(comment);
    }
}
