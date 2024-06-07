using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Services;

namespace ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(){

        var categoriesDto = await _categoryService.GetCategories();

        if(categoriesDto is null){
            return NotFound("Categories not found");
        }

        return Ok(categoriesDto);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts(){

        var categoriesDto = await _categoryService.GetCategoriesProducts();

        if(categoriesDto is null){
            return NotFound("Categories not found");
        }

        return Ok(categoriesDto);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> Get(int id){

        var categoriesDto = await _categoryService.GetCategoryById(id);
        
        if(categoriesDto is null){
            return NotFound("Category not found");
        }

        return Ok(categoriesDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto){

        if(categoryDto is null){
            return BadRequest("Invalid Data");
        }

        await _categoryService.AddCategory(categoryDto);

        return new CreatedAtRouteResult("GetCategory", new {id = categoryDto.CategoryId }, categoryDto);

    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto){

        if(id != categoryDto.CategoryId || categoryDto is null){
            return BadRequest();
        }

        await _categoryService.UpdateCategory(categoryDto);

        return Ok(categoryDto);

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> Delete(int id){

        var categoriesDto = await _categoryService.GetCategoryById(id);

        if(categoriesDto is null){
            return NotFound("Category not found");
        }

        await _categoryService.RemoveCategory(id);

        return Ok(categoriesDto);

    }

    

}