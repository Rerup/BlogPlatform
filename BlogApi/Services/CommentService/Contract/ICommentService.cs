using System;
using Domain.BlogDomain;

namespace BlogApi.Services.CommentService.Contract;

public interface ICommentService
{
    Task<Comment> AddCommentAsync(Comment comment);

    Task<Comment> DeleteCommentAsync(Comment comment);

    Task<Comment> GetComment(int id);
}
