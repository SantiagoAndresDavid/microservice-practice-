
using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : Controller
{
    private IAppDBContext _context;
    public PostController(IAppDBContext context) => _context = context;

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var response = await _context.Posts.Where(w => w.type == true).ToListAsync();
        if (response == null) return NotFound();
        return Ok(response);
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        var response = await _context.Posts.Where(w => w.Id == Id).FirstOrDefaultAsync();
        if (response == null) return NotFound();
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Post(Post post) 
    {
        var category = _context.Categories.Where(w => w.Id == post.CategoryId).AsNoTracking().FirstOrDefault();
        if (category == null) return NotFound($"La categoria no existe:{post.CategoryId}");
        post.Category = null;
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return Ok(post);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(Post category, Guid Id)
    {
        if (Id != category.Id) throw new Exception();
        var response = await _context.Posts.Where(w => w.Id == Id).FirstOrDefaultAsync();
        if (response == null) return NotFound();
        response.Title = category.Title;
        response.Content = category.Content;
        response.CategoryId = category.CategoryId;
        response.type = category.type;
        await _context.SaveChangesAsync();
        return Ok(response);
    }


    [HttpDelete("Id")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var response = await _context.Posts.Where(w => w.Id == Id).FirstOrDefaultAsync();
        if (response == null) return NotFound();
        _context.Posts.Remove(response);
        await _context.SaveChangesAsync();
        return Ok(Id);

    }
}