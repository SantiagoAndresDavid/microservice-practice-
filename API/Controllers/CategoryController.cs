using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private IAppDBContext _context;

    public CategoryController(IAppDBContext context)
    {
        _context = context;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        var response = await _context.Categories.Where(w => w.Id == Id).FirstOrDefaultAsync();
        if (response == null) return NotFound();
        return Ok(response);
    }

    [Route("category")]
    [HttpPost]
    public async Task<Category> Post(Category category)
    {
        try
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch (Exception ex)
        {
            // Aquí puedes registrar el error, por ejemplo, usando un logger
            // logger.LogError(ex, "An error occurred while adding the category");
            throw new Exception("An error occurred while adding the category", ex);
        }
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(Category category, Guid Id)
    {
        if (Id != category.Id) throw new Exception();
        var response = await _context.Categories.Where(w => w.Id == Id).FirstOrDefaultAsync();
        if (response == null) return NotFound();
        response.Description = category.Description;
        await _context.SaveChangesAsync();
        return Ok(response);
    }
    
    [HttpDelete]
    public IActionResult Delet() => throw new NotImplementedException();
}
    

    
