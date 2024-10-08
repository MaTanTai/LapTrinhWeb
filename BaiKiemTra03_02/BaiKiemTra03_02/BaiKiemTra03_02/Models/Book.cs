using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_02.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Không được để trống Tiêu đề sách!")]
        [Display(Name = "Tiêu đề sách")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Không được để trống Năm xuất bản!")]
        [Display(Name = "Năm xuất bản")]
        [Range(1000, 9999, ErrorMessage = "Năm xuất bản không hợp lệ!")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Không được để trống Mã tác giả!")]
        [Display(Name = "Mã tác giả")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Không được để trống Thể loại!")]
        [Display(Name = "Thể loại")]
        public string Genre { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Thuộc tính điều hướng đến tác giả
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; } // Đây là thuộc tính điều hướng
    }
}
