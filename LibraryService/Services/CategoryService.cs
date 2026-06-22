
using AutoMapper;
using LibraryCore;
using LibraryDataAccess.DTOs;
using LibraryDataAccess.Repositories;
using LibraryService.Interfaces;
using LibraryService.Response;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _categoryRepository;

    private readonly IMapper _mapper;
    public CategoryService(IGenericRepository<Category> categoryRepository, IMapper mapper){
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public Task<IResponse<CategoryCreateDto>> Create(CategoryCreateDto categoryCrateDto)
    {
        try
        {
            if(categoryCrateDto == null)
           {
            return Task.FromResult<IResponse<CategoryCreateDto>>(ResponseGeneric<CategoryCreateDto>.Error("Category cannot be null."));
           }
         var categoryEntity = new Category{Description = categoryCrateDto.Description, Name = categoryCrateDto.Name};
        _categoryRepository.Create(categoryEntity);
         
         return Task.FromResult<IResponse<CategoryCreateDto>>(ResponseGeneric<CategoryCreateDto>.Success(null, "Category created successfully."));
        }

        catch (Exception ex)
        {
            return Task.FromResult<IResponse<CategoryCreateDto>>(ResponseGeneric<CategoryCreateDto>.Error($"An error occurred while creating the category: {ex.Message}"));
        }
    }

    public IResponse<CategoryQueryDto> Delete(int id)
    {
        try
        {
            var category = _categoryRepository.GetByIdAsync(id).Result;
            if (category == null)
            {
                return ResponseGeneric<CategoryQueryDto>.Error("Category not found.");
            }
        _categoryRepository.Delete(category);
        return ResponseGeneric<CategoryQueryDto>.Success(null, "Category deleted successfully.");
        }
        catch (Exception ex)
        {
            return ResponseGeneric<CategoryQueryDto>.Error($"An error occurred while deleting the category: {ex.Message}");
        }
    }

    public IResponse<CategoryQueryDto> GetById(int id)
    {
        try
        {
             var category = _categoryRepository.GetByIdAsync(id).Result;
             var categoryDto = _mapper.Map<CategoryQueryDto>(category);
        if (categoryDto == null)
        {
            return ResponseGeneric<CategoryQueryDto>.Success(null, "Category not found.");
        }
        return ResponseGeneric<CategoryQueryDto>.Success(categoryDto, "Category retrieved successfully.");
        }

        catch (Exception ex)
        {
            return ResponseGeneric<CategoryQueryDto>.Error($"An error occurred while retrieving the category: {ex.Message}");
        }
    }

    public IResponse<IEnumerable<CategoryQueryDto>> GetByName(string name)
    {
        try
        {
            var categories = _categoryRepository.GetAll().Where(c => c.Name != null && c.Name.ToLower().Contains(name.ToLower())).ToList();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryQueryDto>>(categories);
        if (categoryDtos == null || categoryDtos.ToList().Count == 0)
        {
            return ResponseGeneric<IEnumerable<CategoryQueryDto>>.Error("No categories found with the given name.");
        }
        return ResponseGeneric<IEnumerable<CategoryQueryDto>>.Success(categoryDtos, "Categories retrieved successfully.");
        }

        catch (Exception ex)
        {
            return ResponseGeneric<IEnumerable<CategoryQueryDto>>.Error($"An error occurred while retrieving categories: {ex.Message}");  
        }
      
    }

    public IResponse<IEnumerable<CategoryQueryDto>> ListAll()
    {
        try
        {
            var categories = _categoryRepository.GetAll().ToList();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryQueryDto>>(categories);
        if (categoryDtos == null || categoryDtos.ToList().Count == 0)
        {
            return ResponseGeneric<IEnumerable<CategoryQueryDto>>.Error("No categories found.");
        }
        return ResponseGeneric<IEnumerable<CategoryQueryDto>>.Success(categoryDtos, "Categories retrieved successfully.");
        }

        catch (Exception ex)
        {
            return ResponseGeneric<IEnumerable<CategoryQueryDto>>.Error($"An error occurred while retrieving categories: {ex.Message}");  
        }
      
    }

    public Task<IResponse<Category>> Update(Category category)
    {
        throw new NotImplementedException();
    }
}