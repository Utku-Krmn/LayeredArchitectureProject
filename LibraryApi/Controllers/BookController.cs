

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

    [HttpGet("GetById")]
    public IActionResult GetById(int id)
    {
        var result = _bookService.GetById(id);

        if(!result.IsSuccess)
        {
            return NotFound("Book not found.");
        }

        return Ok(result);
    }

    [HttpGet("GetBooksByCategoryId")]
    public IActionResult GetBooksByCategoryId(int categoryId)
    {
        var result = _bookService.GetBooksByCategoryId(categoryId);

        if(!result.IsSuccess)
        {
            return NotFound("No books found with the given category.");
        }

        return Ok(result);
    }

    [HttpGet("GetBooksByAuthorId")]
    public IActionResult GetBooksByAuthorId(int authorId)
    {
        var result = _bookService.GetBooksByAuthorId(authorId);
        if(!result.IsSuccess)
        {
            return NotFound("No books found with the given author.");
        }
        return Ok(result);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] BookUpdateDto bookupdatedto)
    {
        if (bookupdatedto == null)
        {
            return BadRequest("Book cannot be null.");
        }

        var result = _bookService.Update(bookupdatedto);

        if (!result.Result.IsSuccess)
        {
            return BadRequest("Book could not be updated.");
        }

        return Ok(result);
    }
  }
}
