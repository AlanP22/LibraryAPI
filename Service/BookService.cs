using FluentValidation;
using FluentValidation.Results;
using AutoMapper;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Controllers;
using LibraryAPI.Repository.Contract;
using LibraryAPI.Service.Contract;

namespace LibraryAPI.Service
{
    public class BookService : IBookService
    {
        public IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _repository = bookRepository;
            _mapper = mapper;
        }

        protected bool ValidateBook(Book bookToValidate)
        {
            BookValidator validator = new BookValidator();
            ValidationResult result = validator.Validate(bookToValidate, opt => opt.ThrowOnFailures());
            return result.IsValid;
        }


        public bool BookExists(int BookId)
        {
            return _repository.BookExists(BookId);
        }
        public ICollection<BookDto> GetBooks()
        {
            var books = _repository.GetBooks();

            if (books == null)
            {
                throw new ArgumentNullException("There are no books!");
            }

            return _mapper.Map<ICollection<BookDto>>(books);
        }
        public Task<ICollection<BookDetailsDto>> GetBooksWithDetails()
        {
            var books = _repository.GetBooksWithDetails();

            if (books == null)
            {
                throw new ArgumentNullException("There are no books!");
            }

            return books;
        }
        public Task<ICollection<Book>> GetBookByID(int BookID)
        {
            if (!_repository.BookExists(BookID))
            {
                throw new KeyNotFoundException("Provided not existing BookID.");
            }

            return _repository.GetBookByID(BookID);
        }
        public Task<ICollection<Book>> GetBookByAuthor(string authorName)
        {
            var bookByAuthor = _repository.GetBookByAuthor(authorName);

            if (bookByAuthor == null)
            {
                throw new KeyNotFoundException("None books found with provided author name.");
            }

            return bookByAuthor;
        }
        public Task<ICollection<Book>> GetBookByTitle(string title)
        {
            var bookByTitle = _repository.GetBookByTitle(title);

            if (bookByTitle == null)
            {
                throw new KeyNotFoundException("None books found with provided title.");
            }

            return bookByTitle;
        }
        public Task<bool> CreateBook(Book book)
        {
            if (!ValidateBook(book))
            {
                throw new ValidationException("Provided invalid value.");
            }

            return _repository.CreateBook(book);
        }
        public Task<bool> UpdateBook(Book book)
        {
            var update = _repository.UpdateBook(book);

            if (_repository.BookExists(book.Id))
            {
                throw new KeyNotFoundException("Provided not existent key.");
            }

            return update;
        }
        public Task<bool> DeleteBook(int Id)
        {
            var delete = _repository.DeleteBook(Id);

            if (_repository.BookExists(Id))
            {
                throw new KeyNotFoundException("Provided not existent key.");
            }

            return delete;
        }
    }
}
