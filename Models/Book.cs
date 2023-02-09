using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Table("Book")]
    public partial class Book
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Rating { get; set; }
        [Column("ISBN")]
        [StringLength(13)]
        public string Isbn { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        [Column("AuthorID")]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        [InverseProperty("Books")]
        public virtual Author Author { get; set; }
    }
}
