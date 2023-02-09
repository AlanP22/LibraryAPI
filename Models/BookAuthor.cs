using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Keyless]
    [Table("BookAuthor")]
    public partial class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; } = null!;
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; } = null!;
    }
}
