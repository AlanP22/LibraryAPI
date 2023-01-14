using LibraryAPI.Resources;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace LibraryAPI
{
    public class BookAuthor
    {
        public int? AuthorID { get; set; }
        public Author Author { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
