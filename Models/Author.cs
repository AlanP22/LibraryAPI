using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Resources
{
    // Author model
    public class Author 
    {
        public Author()
        {
            Books = new List<Book>();
        }
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;
        // birth date can be passed in DateOnly format (rrrr-mm-dd) because of added conversion
        [Column(TypeName = "Datetime2")]
        public DateTime BirthDate { get; set; } 
        // Gender data is converted from string values male/female to bit values in custom coversion
        [Column(TypeName = "bit")]
        public string Gender { get; set; }
        public virtual ICollection<Book>? Books { get; set; }

    }
}
