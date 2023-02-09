using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTOs
{
    public class BookDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title can be up to 100 characters.")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string AuthorName { get; set; }

    }

    public class BookDetailsDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title can be up to 100 characters.")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public decimal Rating { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
