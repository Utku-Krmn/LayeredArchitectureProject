using LibraryCore;
using LibraryDataAccess.DTOs;
using LibraryService.Response;

namespace LibraryService.Interfaces
{
   

    public interface ICategoryService
    {
      IResponse<IEnumerable<CategoryQueryDto>> ListAll();
      IResponse<CategoryQueryDto> GetById(int id);
      Task<IResponse<CategoryCreateDto>> Create(CategoryCreateDto category);
      Task<IResponse<Category>> Update(Category category);
      IResponse<CategoryQueryDto> Delete(int id);
      IResponse<IEnumerable<CategoryQueryDto>> GetByName(string name);
    }
      
}