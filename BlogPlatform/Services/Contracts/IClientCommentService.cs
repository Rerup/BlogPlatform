using System;
using Domain.BlogDomain;

namespace BlogPlatform.Services.Contracts;

public interface IClientCommentService
{

    Task<Comment> AddCommentAsync(Comment comment);
    Task DeleteCommentAsync(int commentId);
}
