using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Get() => throw new NotImplementedException();
    
    [HttpPost]
    public IActionResult Post() => throw new NotImplementedException();
    
    [HttpPut]
    public IActionResult Put() => throw new NotImplementedException();
    
    [HttpDelete]
    public IActionResult Delet() => throw new NotImplementedException();
    
}