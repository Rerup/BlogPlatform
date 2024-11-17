using BlogApi.Data;
using BlogApi.Domain.BlogDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BlogController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _context.Blog.Include(b => b.Comments).ToListAsync();

            return Ok(blogs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _context.Blog.Include(b => b.Comments).FirstOrDefaultAsync(b => b.Id == id);

            return blog == null ? NotFound() : Ok(blog);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, Blog blog)
        {
            blog = await _context.Blog.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            _context.Update(blog);

            await _context.SaveChangesAsync();

            return Ok(blog);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostBlog(Blog blog)
        {
            if (blog == null)
            {
                return BadRequest();
            }

            _context.Blog.Add(blog);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostBlog), new { id = blog.Id }, blog);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {

            var blog = await _context.Blog.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            _context.Blog.Remove(blog);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}

