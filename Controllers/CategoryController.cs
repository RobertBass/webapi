using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    protected readonly ICategoryService categoryService;

    public CategoryController(ICategoryService category)
    {
        categoryService = category;
    }
    

    [HttpGet(Name = "GetCategories")]
    [Route("Get/categories")]
    [Route("categories")]
    public IActionResult Get()
    {
        return Ok(categoryService.GetCategories());
    }


    [HttpPost]
    [Route("Post/categories")]
    [Route("categories")]
    public IActionResult Post([FromBody] Category category)
    {
        categoryService.AddCategory(category);
        return Ok(category);
    }


    [HttpPut("{id}")]
    [Route("Put/categories/{id}")]
    [Route("categories/{id}")]
    public IActionResult Put(Guid id, [FromBody] Category category)
    {
        categoryService.UpdateCategory(id, category);
        return Ok(category);
    }


    [HttpDelete("{id}")]
    [Route("Delete/categories/{id}")]
    public IActionResult Delete(Guid id)
    {
        categoryService.DeleteCategory(id);
        return Ok();
    }
}