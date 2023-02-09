using LibraryAPI.Controllers;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            this._context = context;
        }

        public BookRepository()
        {
        }

        public bool BookExists(int BookID)
        {
            return _context.Book.Any(book => book.Id == BookID);
        }
        public async Task<ICollection<Book>> GetBooks()
        {
            return await _context.Book.Include(b => b.Author).ToListAsync();
        }
        public async Task<ICollection<BookDetailsDto>> GetBooksWithDetails()
        {
            var books = await _context.Book.Include(b => b.Author).ToListAsync();

            var booksDtos = from b in books
                        select new BookDetailsDto()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Description = b.Description,
                            AuthorID = b.AuthorId,
                            AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                            Rating = b.Rating,
                            ISBN = b.Isbn,
                            PublicationDate = b.PublicationDate
                        };
            return booksDtos as ICollection<BookDetailsDto>;
        }
        public async Task<ICollection<Book>> GetBookByID(int BookID)
        {
            return await _context.Book.Include(b => b.AuthorId).FirstOrDefaultAsync(b => b.Id == BookID) as ICollection<Book>;
        }
        public async Task<ICollection<Book>> GetBookByAuthor(string authorName)
        {
            return await _context.Book.Include(b => b.AuthorId)
                                      .Where(b => b.Author.FirstName + " " + b.Author.LastName == authorName)
                                      .ToListAsync();
        }
        public async Task<ICollection<Book>> GetBookByTitle(string title)
        {
            return await _context.Book.Include(b => b.AuthorId)
                                      .Where(b => b.Title == title)
                                      .ToListAsync();
        }
        public async Task<bool> CreateBook(Book book)
        {
            try
            {
                await _context.Book.AddAsync(book);
                await _context.SaveChangesAsync();
                return true;
            }

            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateBook(Book book)
        {
            try
            {
                _context.Book.Update(book);
                await _context.SaveChangesAsync();
                return true;
            }

            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteBook(int Id)
        {
            try
            {
                var book = (Book)_context.Book.Where(b => b.Id == Id);
                _context.Book.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
