

using LibraryDataAccess.DTOs;
using LibraryService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
  public class BookController : ControllerBase
  {
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
   

    [HttpGet("ListAll")]
    public IActionResult GetAll()
    {   
         var books = _bookService.ListAll();

         if(!books.IsSuccess)
         {
            return NotFound("No books found.");
         }

        return Ok(books);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        var result = _bookService.Delete(id);
        if(!result.IsSuccess)
        {
            return BadRequest("Book not found.");
        }
        return Ok(result);
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] BookCreateDto book)
    {
        if(book == null)
        {
            return BadRequest("Book cannot be null.");
        }   
        var result = _bookService.Create(book);

        if(!result.Result.IsSuccess)
        {
            return BadRequest("Book could not be created.");
        }
        return Ok(result);
    }

    [HttpPut("GetById")]
    public IActionResult GetById(int id)
    {
        var result = _bookService.GetById(id);

        if(!result.IsSuccess)
        {
            return NotFound("Book not found.");
        }

        return Ok(result);
    }
    
  }
} 
