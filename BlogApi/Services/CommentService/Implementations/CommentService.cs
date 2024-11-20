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

    public Task<Comment> GetComment(int id)
    {
        return _commentRepository.GetById(id);
    }

    public Task<Comment> AddCommentAsync(Comment comment)
    {
        return _commentRepository.Add(comment);
    }

    public Task<Comment> DeleteCommentAsync(Comment comment)
    {
        return _commentRepository.Delete(comment);
    }
}
