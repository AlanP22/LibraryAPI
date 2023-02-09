using AutoMapper;
using LibraryAPI.Controllers;

namespace LibraryAPI.Models.DTOs.BookDtos
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDto>()
            .ForMember(desc => desc.AuthorName,
                opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));
            CreateMap<List<Book>, ICollection<BookDto>>().IncludeAllDerived();
            CreateMap<Book, BookDetailsDto>()
            .ForMember(desc => desc.AuthorID,
                opt => opt.MapFrom(src => src.Author.Id))
            .ForMember(desc => desc.AuthorName,
                opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));
        }
    }
}
