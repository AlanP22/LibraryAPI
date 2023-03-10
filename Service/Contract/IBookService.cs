using LibraryAPI.Controllers;
using LibraryAPI.Models.DTOs;

namespace LibraryAPI.Service.Contract
{
    public interface IBookService
    {
        ICollection<BookDto> GetBooks();
        Task<ICollection<BookDetailsDto>> GetBooksWithDetails();
        Task<ICollection<Book>> GetBookByID(int BookID);
        Task<ICollection<Book>> GetBookByAuthor(string authorName);
        Task<ICollection<Book>> GetBookByTitle(string authorName);
        Task<bool> CreateBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int Id);
        bool BookExists(int BookID);
    }
}
