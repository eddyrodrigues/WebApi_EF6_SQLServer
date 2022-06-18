namespace Blog.Controllers;

using Blog.Domain.Arguments;
using Blog.Domain.Entities;
using Blog.Service.Services;
using Microsoft.AspNetCore.Mvc;

[Route("v1/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
  private readonly CategoryService _categoryService;

  public CategoryController(CategoryService categoryService)
  {
    _categoryService = categoryService;
  }
  [HttpGet]
  public async Task<IActionResult> Get()
  {

    return Ok(_categoryService.GetAllCategories());
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CategoryArgument categoryArgument)
  {
    if (!ModelState.IsValid)
      return Ok(new ResultArgument<Category>("Não foi possível validar sua requisição. Favor rever os campos e tentar novamente."));

    if (!categoryArgument.IsValid)
      return Ok(new ResultArgument<Category>(categoryArgument.Notifications.Select(n => $"{n.Key} - {n.Message}").ToList()));
      
    return Ok(_categoryService.AddCategory(categoryArgument));
  }
}