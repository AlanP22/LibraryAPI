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
        public int ISBN { get; set; }
        [Column(TypeName = "Datetime2")]
        public DateOnly PublicationDate { get; set; }

    }
}
