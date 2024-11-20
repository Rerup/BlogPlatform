using BlogApi.Services.CommentService.Contract;
using Domain.BlogDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")] // backwards compatibility
    [ApiVersion("1.0")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCommentAsync(Comment comment)
        {
            var addedComment = await _commentService.AddCommentAsync(comment);

            return Ok(addedComment);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int id)
        {
            var comment = await _commentService.GetComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            await _commentService.DeleteCommentAsync(comment);

            return Ok();
        }
    }
}