using Microsoft.AspNetCore.Mvc;
using LibraryService.Interfaces;
using LibraryCore.DTOs;
namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("ListAll")]
        public IActionResult GetAll()
        {   
             var authors = _authorService.ListAll();

             if(!authors.IsSuccess)
             {
                return NotFound("No authors found.");
             }

            return Ok(authors);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _authorService.Delete(id);

            if(!result.IsSuccess)
            {
                return BadRequest("Author not found.");
            }

            return Ok(result);
        }

        [HttpPost("Create")]
        
        public IActionResult Create([FromBody] AuthorCreateDto author)
        {
            if(author == null)
            {
                return BadRequest("Author cannot be null.");
            }

            var result = _authorService.Create(author);

            if(!result.Result.IsSuccess)
            {
                return BadRequest("Author could not be created.");
            }

            return Ok(result);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var result = _authorService.GetByName(name);

            if(!result.IsSuccess)
            {
                return BadRequest("Author not found.");
            }

            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] AuthorUpdateDto authorUpdateDto)
        {
            if(authorUpdateDto == null)
            {
                return BadRequest("Author cannot be null.");
            }

            var result = _authorService.Update(authorUpdateDto);

            if(!result.Result.IsSuccess)
            {
                return BadRequest("Author could not be updated.");
            }

            return Ok(result.Result.Message);
        }
    }
}
