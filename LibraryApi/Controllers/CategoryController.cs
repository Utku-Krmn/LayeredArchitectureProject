  using LibraryCore;
    using LibraryDataAccess.DTOs;
    using LibraryService.Interfaces;
    using Microsoft.AspNetCore.Mvc;


namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class CategoryController : ControllerBase
    {
      private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            var categories = _categoryService.ListAll();
            if (categories.IsSuccess)
            {
                return Ok(categories.Data);
            }
            return NotFound(categories.Message);
        }

        [HttpDelete("Delete")]       
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return NotFound(result.Message);
        }
    
         [HttpPost("Create")]
        public IActionResult Create([FromBody] CategoryCreateDto category )
        {
            if(category == null)
            {
                return BadRequest("Category data is required.");
            }
            var result = _categoryService.Create(category);
            if (result.Result.IsSuccess)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest("Failed to create category: ");
        }
           
         [HttpGet("GetById")]  

        public IActionResult GetById(int id)
        {
           
            var result = _categoryService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound("Category not found with the provided ID.");
        }

          [HttpGet("GetByName")]  

        public IActionResult GetByName(string name)
        {
            var result = _categoryService.GetByName(name);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound("Category not found with the provided name.");
        }

           



    }


}