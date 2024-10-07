using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_02.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public string Genre { get; set; }

        public Author Author { get; set; }
    }
}