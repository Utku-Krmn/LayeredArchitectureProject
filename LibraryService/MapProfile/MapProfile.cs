

using AutoMapper;
using LibraryCore;
using LibraryCore.DTOs;
using LibraryDataAccess.DTOs;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<AuthorCreateDto, Author>().ReverseMap();
        CreateMap<Author, AuthorQueryDto>().ReverseMap();
        CreateMap<Book, BookCreateDto>().ReverseMap();
        CreateMap<Book, BookQueryDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryQueryDto>().ReverseMap();

    }
}