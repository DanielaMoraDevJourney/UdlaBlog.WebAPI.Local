using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdlaBlog.Application.DTOs;
using UdlaBlog.Domain.Entities;
using UdlaBlog.Domain.Interfaces;

[Route("api/nodo/blogs")]
[ApiController]
public class BlogNodoController : ControllerBase
{
    private readonly IBlogNodoRepository _blogRepository;

    public BlogNodoController(IBlogNodoRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogNodo>>> GetBlogs()
    {
        var blogs = await _blogRepository.GetAllAsync();
        return Ok(blogs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogNodo>> GetBlog(Guid id)
    {
        var blog = await _blogRepository.GetByIdAsync(id);
        if (blog == null)
        {
            return NotFound();
        }
        return Ok(blog);
    }

    [HttpGet("byTitle/{title}")]
    public async Task<ActionResult<BlogNodo>> GetBlogByTitle(string title)
    {
        var blog = await _blogRepository.GetByTitleAsync(title);
        if (blog == null)
        {
            return NotFound();
        }
        return Ok(blog);
    }

    [HttpPost]
    public async Task<ActionResult> PostBlog(BlogNodoDto blogNodoDto)
    {
        var blogNodo = new BlogNodo
        {
            Titulo = blogNodoDto.Titulo,
            Contenido = blogNodoDto.Contenido,
            Comments = new List<Comment>()
        };

        await _blogRepository.AddAsync(blogNodo);
        return CreatedAtAction(nameof(GetBlog), new { id = blogNodo.Id }, blogNodo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBlog(Guid id, BlogNodoDto blogNodoDto)
    {
        if (id != blogNodoDto.Id)
        {
            return BadRequest();
        }

        var blogNodo = new BlogNodo
        {
            Id = blogNodoDto.Id,
            Titulo = blogNodoDto.Titulo,
            Contenido = blogNodoDto.Contenido,
            Comments = new List<Comment>()
        };

        await _blogRepository.UpdateAsync(blogNodo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(Guid id)
    {
        await _blogRepository.DeleteAsync(id);
        return NoContent();
    }
}
