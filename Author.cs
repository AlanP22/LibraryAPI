using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Resources
{
    // Author model
    public class Author 
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "Datetime2")]
        public DateOnly BirthDate { get; set; } 
        [Column(TypeName = "bit")]
        public string Gender { get; set; } 

    }
}
