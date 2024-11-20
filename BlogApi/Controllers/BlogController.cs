using Domain.BlogDomain;
using BlogApi.Services.BlogService.Contract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")] // backwards compatibility
    [ApiVersion("1.0")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly IBlogService _blogService;

        public BlogController(IBlogService service)
        {
            _blogService = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _blogService.GetBlogs();

            return Ok(blogs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _blogService.GetBlogWithComments(id);

            return blog is null ? NotFound() : Ok(blog);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, Blog blog)
        {
            var existingBlog = await _blogService.GetBlog(id);

            if (existingBlog is null)
            {
                return NotFound();
            }

            var updatedBlog = await _blogService.UpdateBlog(existingBlog, blog);

            return Ok(updatedBlog);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostBlog(Blog blog)
        {
            if (blog is null)
            {
                return BadRequest();
            }

            await _blogService.CreateBlog(blog);

            return CreatedAtAction(nameof(PostBlog), new { id = blog.Id }, blog);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {

            var blog = await _blogService.GetBlog(id);

            if (blog is null)
            {
                return NotFound();
            }

            await _blogService.DeleteBlog(blog);

            return NoContent();
        }
    }

}

