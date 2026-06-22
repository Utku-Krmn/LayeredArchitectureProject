
using LibraryCore;
using LibraryService.Interfaces;
using LibraryService.Response;
using LibraryDataAccess.Repositories;
using LibraryDataAccess.DTOs;
using AutoMapper;
public class BookService : IBookService
{
    
    // Implement the IBookService interface using the IGenericRepository<Book> for data access.
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly IMapper _mapper;
    public BookService(IGenericRepository<Book> bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
     public Task<IResponse<BookCreateDto>> Create(BookCreateDto createBookModel)
    {
        try
        {
              if(createBookModel == null)
        {
            return Task.FromResult<IResponse<BookCreateDto>>(ResponseGeneric<BookCreateDto>.Error("Book cannot be null"));
        }
        var book = new Book
        {
            Title = createBookModel.Title,
            PublicationYear = createBookModel.PublicationYear,
            CategoryId = createBookModel.CategoryId,
            CountOfPages = createBookModel.CountOfPages,
            AuthorId = createBookModel.AuthorId
        };

       _bookRepository.Create(book);
       var bookDto = _mapper.Map<BookCreateDto>(book);
       return Task.FromResult<IResponse<BookCreateDto>>(ResponseGeneric<BookCreateDto>.Success(bookDto, "Book created successfully"));
        }
        catch(Exception ex)
        {
            return Task.FromResult<IResponse<BookCreateDto>>(ResponseGeneric<BookCreateDto>.Error($"An error occurred while creating the book: {ex.Message}"));
        }
    }

    public IResponse<BookQueryDto> Delete(int id)
    {
        try
        {
          var book = _bookRepository.GetByIdAsync(id).Result;
        if(book == null)
        {
            return ResponseGeneric<BookQueryDto>.Error("Book not found");
        }
        _bookRepository.Delete(book);
        return ResponseGeneric<BookQueryDto>.Success(null, "Book deleted successfully");
        }
        catch(Exception ex)
        {
            return ResponseGeneric<BookQueryDto>.Error($"An error occurred while deleting the book: {ex.Message}");
        }
    }

    public IResponse<BookQueryDto> GetById(int id)
    {
        try
        {
          var book = _bookRepository.GetByIdAsync(id).Result;

          var bookDto = _mapper.Map<BookQueryDto>(book);
        if(bookDto == null)
        {
            return ResponseGeneric<BookQueryDto>.Success(null, "Book not found");
        }
        return ResponseGeneric<BookQueryDto>.Success(bookDto, "Book retrieved successfully");
        }
        catch(Exception ex)
        {
            return ResponseGeneric<BookQueryDto>.Error($"An error occurred while retrieving the book: {ex.Message}");
        }
    }
     public IResponse<IEnumerable<BookQueryDto>> GetByName(string name)
    {
        try
        {
          var books = _bookRepository.GetAll().Where(x => x.Title == name).ToList();

          var bookDtos = _mapper.Map<IEnumerable<BookQueryDto>>(books);
        if(bookDtos == null || bookDtos.Count() == 0)
        {
            return ResponseGeneric<IEnumerable<BookQueryDto>>.Error("No books found with the given name");
        }
        return ResponseGeneric<IEnumerable<BookQueryDto>>.Success(bookDtos, "Books retrieved successfully");
        }
        catch(Exception ex)
        {
            return ResponseGeneric<IEnumerable<BookQueryDto>>.Error($"An error occurred while retrieving books: {ex.Message}");
        }
    }

    public IResponse<IEnumerable<BookQueryDto>> ListAll()
    {
        try
        {
          var bookList = _bookRepository.GetAll().ToList();

          var bookListDtos = _mapper.Map<IEnumerable<BookQueryDto>>(bookList);
        if(bookListDtos == null || bookListDtos.Count() == 0)
        {
            return ResponseGeneric<IEnumerable<BookQueryDto>>.Error("No books found");
        }
        return ResponseGeneric<IEnumerable<BookQueryDto>>.Success(bookListDtos, "Books retrieved successfully");
        }
        catch(Exception ex)
        {
            return ResponseGeneric<IEnumerable<BookQueryDto>>.Error($"An error occurred while retrieving books: {ex.Message}");
        }
    }
     public Task<IResponse<Book>> Update(BookQueryDto book)
    {
        throw new NotImplementedException();
    }
    
}

