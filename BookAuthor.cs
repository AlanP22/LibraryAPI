using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Resources
{
    public class BookAuthor
    {
        [Column(TypeName = "Foreign Key")]
        public int BookId { get; set; }
        [Column(TypeName = "Foreign Key")]
        public int AuthorId { get; set; }
    }
}
