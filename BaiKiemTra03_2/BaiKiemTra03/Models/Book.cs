using System.ComponentModel.DataAnnotations;
namespace BaiKiemTra03.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }

        [Required(ErrorMessage = "Tác giả là bắt buộc.")]
        public int AuthorId { get; set; } // Thêm thuộc tính AuthorId

        // Navigation property
        public Author Author { get; set; }
    }
}
