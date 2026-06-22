using LibraryCore;
using LibraryService.Response;
using LibraryDataAccess.DTOs;

namespace LibraryService.Interfaces
{

    public interface IBookService
    {
      IResponse<IEnumerable<BookQueryDto>> ListAll();
      IResponse<BookQueryDto> GetById(int id);
      Task<IResponse<BookCreateDto>> Create(BookCreateDto book);
      Task<IResponse<Book>> Update(BookQueryDto book);
      IResponse<BookQueryDto> Delete(int id);
      IResponse<IEnumerable<BookQueryDto>> GetByName(string name);
    }
}