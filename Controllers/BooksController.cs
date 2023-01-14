using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Resources;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // All get methods (exept by id) are returning only author name, instead of whole author enitity, to make output cleared

        //Read all books - GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {

            var books = await _context.Book
                                      .Include(b => b.Author)
                                       .Select(b => new
                                       {
                                           b.Id,
                                           b.Title,
                                           b.Description,
                                           AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                                           b.Rating,
                                           b.ISBN,
                                           b.PublicationDate         
                                       })
                                       .ToListAsync();
            return Ok(books);
        }

        //Book search by author name - GET: api/Books/ByAuthor/[authorName]
        [HttpGet("ByAuthor/{authorName}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(string authorName)
        {
            var books = await _context.Book
                                      .Include(b => b.Author)
                                       .Where(b => b.Author.FirstName + " " + b.Author.LastName == authorName)
                                       .Select(b => new
                                       {
                                           b.Id,
                                           b.Title,
                                           b.Description,
                                           AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                                           b.Rating,
                                           b.ISBN,
                                           b.PublicationDate
                                       })
                                       .ToListAsync();

            if (!books.Any())
            {
                return NotFound();
            }


            return Ok(books);
        }

        //Book search by title - GET: api/Books/ByTitle/[Title]
        [HttpGet("ByTitle/{title}")]
        public async Task<ActionResult<Book>> GetBookByTitle(string title)
        {
            var books = await _context.Book
                                      .Include(b => b.Author)
                                      .Where(b => b.Title == title)
                                       .Select(b => new
                                       {
                                           b.Id,
                                           b.Title,
                                           b.Description,
                                           AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                                           b.Rating,
                                           b.ISBN,
                                           b.PublicationDate
                                       })
                                       .ToListAsync();

            if (!books.Any())
            {
                return NotFound();
            }


            return Ok(books);
        }

        //Book search by id - GET: api/Books/[id]
        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = _context.Book.Include(b => b.Author)
                                    .Where(b => b.Id == id);
            if (!book.Any())
            {
                return NotFound();
            }

            return Ok(book);
        }



        //Edit boot - PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book bookUpdate)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Entry(book).CurrentValues.SetValues(bookUpdate);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Add book - POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await _context.Author.FindAsync(book.AuthorID);

            if (author == null)
            {
                throw new Exception("Author not found");
            }

            author.Books.Add(book);
            book.Author = author;

            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        //Delete book - DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
