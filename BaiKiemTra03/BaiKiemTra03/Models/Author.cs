using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Tên tác giả là bắt buộc.")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Quốc tịch là bắt buộc.")]
        public string Nationality { get; set; }

        [Range(1900, 2100, ErrorMessage = "Năm sinh phải nằm trong khoảng từ 1900 đến 2100.")]
        public int BirthYear { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; } = new List<Book>(); // Khởi tạo danh sách
    }
}
