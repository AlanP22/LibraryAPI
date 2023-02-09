using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AuthorsController(LibraryContext context)
        {
            _context = context;
        }

        //Read all authors - GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {

            return await _context.Author.Include("Books").ToListAsync();
        }


        // Author search by full name - GET: api/Author/ByName/[FullName]
        [HttpGet("ByName/{FullName}")]
        public async Task<ActionResult<Author>> GetAuthorByName(string FullName)
        {
            var author = await _context.Author
                                        .Include(a => a.Books)
                                        .Where(a => a.FirstName + " " + a.LastName == FullName)
                                        .ToListAsync();

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        //Author search by Id - GET: api/Authors/[id]
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Author.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        //Add author - POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Author.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        private bool AuthorExists(int id)
        {
            return _context.Author.Any(e => e.Id == id);
        }
    }
}
