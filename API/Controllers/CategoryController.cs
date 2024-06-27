using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Mvc;


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

    [HttpGet]
    public IActionResult Get() => throw new NotImplementedException();
    
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

    [HttpPut]
    public IActionResult Put() => throw new NotImplementedException();
    
    [HttpDelete]
    public IActionResult Delet() => throw new NotImplementedException();
    
}