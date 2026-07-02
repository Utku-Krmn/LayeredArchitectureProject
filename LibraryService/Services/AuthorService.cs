using LibraryDataAccess.Repositories;
using LibraryCore;
using LibraryService.Interfaces;
using LibraryService.Response;
using LibraryCore.DTOs;
using AutoMapper;

public class AuthorService : IAuthorService
{
    //We use Dependency Injection to inject the IGenericRepository<Author> into the AuthorService class. This allows us to use the repository methods to perform CRUD operations on the Author entity without tightly coupling our service to a specific data access implementation.
    private readonly IGenericRepository<Author> _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IGenericRepository<Author> authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }
    public Task<IResponse<Author>> Create(AuthorCreateDto authorCreateDto)
    {
        try
        {
            
        if(authorCreateDto == null)
        {
            return Task.FromResult<IResponse<Author>>(ResponseGeneric<Author>.Error("Author cannot be null."));
        }

        var newAuthor = _mapper.Map<Author>(authorCreateDto); // We use AutoMapper to map the AuthorCreateDto to an Author entity. This simplifies the process of converting between different object types and reduces boilerplate code.
        newAuthor.RecordTime = DateTime.UtcNow;
        _authorRepository.Create(newAuthor);

        return Task.FromResult<IResponse<Author>>(ResponseGeneric<Author>.Success(newAuthor, "Author created successfully."));
        }

        catch (Exception ex)
        {
            return Task.FromResult<IResponse<Author>>(ResponseGeneric<Author>.Error($"An error occurred while creating the author: {ex.Message}"));
        }
    }

    public IResponse<Author> Delete(int id)
    {
        try
        {
              var author = _authorRepository.GetByIdAsync(id).Result;
        if (author == null)
        {
            return ResponseGeneric<Author>.Error("Author not found.");
        }
        _authorRepository.Delete(author);
        return ResponseGeneric<Author>.Success(author, "Author deleted successfully.");
        }

        catch (Exception ex)
        {
            return ResponseGeneric<Author>.Error($"An error occurred while deleting the author: {ex.Message}");
        }
    }

    public IResponse<AuthorQueryDto> GetById(int id)
    {
        try
        {
             var author = _authorRepository.GetByIdAsync(id).Result;
             var authorQueryDto = _mapper.Map<AuthorQueryDto>(author); 
            if (author == null)
            {

            return ResponseGeneric<AuthorQueryDto>.Success(null, "Author not found.");

            }
        return ResponseGeneric<AuthorQueryDto>.Success(authorQueryDto, "Author retrieved successfully.");
        }

        catch (Exception ex)
        {
            return ResponseGeneric<AuthorQueryDto>.Error($"An error occurred while retrieving the author: {ex.Message}");
        }
    }

    public IResponse<IEnumerable<AuthorQueryDto>> GetByName(string name)
    {
        try
        {
            var authors = _authorRepository.GetAll().Where(a => a.Name != null && a.Name.Contains(name)).ToList();
            var authorqueryDtos = _mapper.Map<IEnumerable<AuthorQueryDto>>(authors);

        if (authorqueryDtos == null || authorqueryDtos.Count() == 0)
        {
            return ResponseGeneric<IEnumerable<AuthorQueryDto>>.Error("No authors found with the given name.");
        }
        return ResponseGeneric<IEnumerable<AuthorQueryDto>>.Success(authorqueryDtos, "Authors retrieved successfully.");
        }

        catch (Exception ex)
        {
            return ResponseGeneric<IEnumerable<AuthorQueryDto>>.Error($"An error occurred while retrieving authors: {ex.Message}");
        }
    }

    public IResponse<IEnumerable<AuthorQueryDto>> ListAll()
    {
        try
        {
            var authors = _authorRepository.GetAll().ToList();
            var authorqueryDtos = _mapper.Map<IEnumerable<AuthorQueryDto>>(authors); // We use AutoMapper to map the list of Author entities to a list of AuthorQueryDto objects. This allows us to return a simplified version of the Author data that is suitable for querying and displaying in the API response.
        if (authors == null || authors.Count == 0)
        {
            return ResponseGeneric<IEnumerable<AuthorQueryDto>>.Error("No authors found.");
        }
        return ResponseGeneric<IEnumerable<AuthorQueryDto>>.Success(authorqueryDtos, "Authors retrieved successfully.");
        }

        catch (Exception ex)
        {
            return ResponseGeneric<IEnumerable<AuthorQueryDto>>.Error($"An error occurred while retrieving authors: {ex.Message}");
        }
  
    }

    public Task<IResponse<AuthorUpdateDto>> Update(AuthorUpdateDto authorUpdateDto)
    {
        try
        {
            var authorentity = _authorRepository.GetByIdAsync(authorUpdateDto.Id).Result;
            if (authorentity == null)
            {
                return Task.FromResult<IResponse<AuthorUpdateDto>>(ResponseGeneric<AuthorUpdateDto>.Error("Author not found."));
            }
            if(authorUpdateDto.Name != null)
            {
                authorentity.Name = authorUpdateDto.Name;
            }
            if(authorUpdateDto.Surname != null)
            {
                authorentity.Surname = authorUpdateDto.Surname;
            }
            if(authorUpdateDto.PlaceOfBirth != null)
            {
                authorentity.PlaceOfBirth = authorUpdateDto.PlaceOfBirth;
            }
            if(authorUpdateDto.BirthYear != 0)
            {
                authorentity.BirthYear = authorUpdateDto.BirthYear;
            }
            if(authorUpdateDto.Biography != null)
            {
                authorentity.Biography = authorUpdateDto.Biography;
            }
            
            _authorRepository.Update(authorentity);

            return Task.FromResult<IResponse<AuthorUpdateDto>>(ResponseGeneric<AuthorUpdateDto>.Success(authorUpdateDto, "Author updated successfully."));
        }

        catch (Exception ex)
        {
            return Task.FromResult<IResponse<AuthorUpdateDto>>(ResponseGeneric<AuthorUpdateDto>.Error($"An error occurred while updating the author: {ex.Message}"));
        }
    }
}