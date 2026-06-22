
using LibraryCore;
using LibraryCore.DTOs;
using LibraryService.Response;

namespace LibraryService.Interfaces
{
    public interface IAuthorService
    {
      IResponse<IEnumerable<AuthorQueryDto>> ListAll();
      IResponse<AuthorQueryDto> GetById(int id);
      Task<IResponse<Author>> Create(AuthorCreateDto author);
      Task<IResponse<Author>> Update(Author author);
      IResponse<Author> Delete(int id);
      IResponse<IEnumerable<AuthorQueryDto>> GetByName(string name);
    }
}