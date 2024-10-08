using BaiKiemTra03.Data;
using BaiKiemTra03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BaiKiemTra03.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var books = _db.Books.Include(b => b.AuthorId).ToList(); // Bao gồm thông tin tác giả
            return View(books);
        }

        // Hiển thị trang thêm sách
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Authors = _db.Authors.ToList(); // Lấy danh sách tác giả
            return View();
        }

        // Xử lý thêm sách
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Authors = _db.Authors.ToList(); // Truyền lại danh sách tác giả khi có lỗi
            return View(book);
        }

        // Hiển thị trang chỉnh sửa sách
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Xử lý chỉnh sửa sách
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // Hiển thị trang xác nhận xóa sách
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Xử lý xóa sách
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Hiển thị chi tiết sách
        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _db.Books.Include(b => b.Author).FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

    }
}
