using LibraryAPI.Repository;
using LibraryAPI.Repository.Contract;
using LibraryAPI.Service;
using LibraryAPI.Models.DTOs;
using LibraryAPI.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService _service;

        public BooksController(IBookService bookService)
        {
            _service = bookService;
        }


        // All get methods (exept by id) are returning only author name, instead of whole author enitity, to make output cleared

        //Read all books - GET: api/Books
        [HttpGet]
        public ActionResult<BookDto> GetBooks()
        {
            return Ok(_service.GetBooks());
        }

        [HttpGet("Details")]
        public async Task<ActionResult> GetBooksWithDetails()
        {
            return Ok(await _service.GetBooksWithDetails());
        }

        //Book search by author name - GET: api/Books/ByAuthor/[authorName]
        [HttpGet("ByAuthor/{authorName}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(string authorName)
        {
            return Ok(await _service.GetBookByAuthor(authorName));
        }

        //Book search by title - GET: api/Books/ByTitle/[Title]
        [HttpGet("ByTitle/{title}")]
        public async Task<ActionResult<Book>> GetBookByTitle(string title)
        {
            return Ok(await _service.GetBookByTitle(title));
        }

        //Book search by id - GET: api/Books/[id]
        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return Ok(await _service.GetBookByID(id));
        }



        //Edit book - PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Book bookUpdate)
        {
            return Ok(await _service.UpdateBook(bookUpdate));
        }

        //Add book - POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            return Ok(await _service.CreateBook(book));
        }

        //Delete book - DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _service.DeleteBook(id));   
        }

        private bool BookExists(int id)
        {
            return _service.BookExists(id);
        }
    }
}
