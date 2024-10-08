using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_02.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Hiển thị danh sách sách
        public IActionResult Index(string searchString)
        {
            List<Book> books;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = _db.Books
                    .Include(b => b.Author) // Kết nối với tác giả
                    .Where(b => b.Title.Contains(searchString) || b.Genre.Contains(searchString))
                    .ToList();
                ViewBag.SearchString = searchString;
            }
            else
            {
                books = _db.Books.Include(b => b.Author).ToList();
            }

            ViewBag.Books = books;
            return View();
        }

        // Thêm sách
        [HttpGet]
        public IActionResult Create()
        {
            var authors = _db.Authors.Select(a => new { a.AuthorId, a.AuthorName }).ToList();
            ViewBag.AuthorList = new SelectList(authors, "AuthorId", "AuthorName");
            return View();
        }

        [HttpPost]

        public IActionResult Create(Book book)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Log lỗi để kiểm tra
                }

                var authors = _db.Authors.Select(a => new { a.AuthorId, a.AuthorName }).ToList();
                ViewBag.AuthorList = new SelectList(authors, "AuthorId", "AuthorName");
                return View(book); // Trả lại view với lỗi đã được hiển thị
            }

            // Nếu ModelState hợp lệ, tiến hành lưu vào database
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Chỉnh sửa sách
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);
            ViewBag.Authors = _db.Authors.ToList();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authors = _db.Authors.ToList();
            return View(book);
        }

        // Xóa sách
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var book = _db.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Chi tiết sách
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var book = _db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            return View(book);
        }
    }
}
