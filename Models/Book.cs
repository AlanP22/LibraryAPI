using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Resources
{
    // Book model
    public class Book
    {

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        [Column(TypeName = "decimal")]
        public float Rating { get; set; }
        [Column(TypeName = "nvarchar(13)")]
        public string ISBN { get; set; }
        // publication date can be passed in DateOnly format (rrrr-mm-dd) because of added conversion
        [Column(TypeName = "Datetime2")]
        public DateTime PublicationDate { get; set; }
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public virtual Author? Author { get; set; }
    }

}
