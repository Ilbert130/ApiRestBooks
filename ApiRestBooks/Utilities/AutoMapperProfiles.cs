using ApiRestBooks.DTOs;
using ApiRestBooks.Models;
using AutoMapper;

namespace ApiRestBooks.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BookCreateDTO, Book>();
            CreateMap<Book, BookDataDTO>();
        }
    }
}
