using BlogApi.Domain.BlogDomain;
using BlogApi.Services.BlogService.Contract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly IBlogService _service;

        public BlogController(IBlogService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _service.GetBlogs();

            return Ok(blogs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _service.GetBlogWithComments(id);

            return blog.Count() < 1 ? NotFound() : Ok(blog);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, Blog blog)
        {
            var existingBlog = await _service.GetBlog(id);

            if (existingBlog == null)
            {
                return NotFound();
            }

            var updatedBlog = await _service.UpdateBlog(existingBlog, blog);

            return Ok(updatedBlog);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostBlog(Blog blog)
        {
            if (blog == null)
            {
                return BadRequest();
            }

            await _service.CreateBlog(blog);

            return CreatedAtAction(nameof(PostBlog), new { id = blog.Id }, blog);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {

            var blog = await _service.GetBlog(id);

            if (blog == null)
            {
                return NotFound();
            }

            await _service.DeleteBlog(blog);

            return NoContent();
        }
    }

}

