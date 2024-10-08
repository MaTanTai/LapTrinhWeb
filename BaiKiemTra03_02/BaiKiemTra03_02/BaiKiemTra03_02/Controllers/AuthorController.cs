﻿using BaiKiemTra03_02.Data;
using BaiKiemTra03_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_02.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Hiển thị danh sách tác giả
        public IActionResult Index()
        {
            var authors = _db.Authors.ToList();
            ViewBag.Authors = authors;
            return View();
        }

        // Thêm tác giả
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Add(author);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // Chỉnh sửa tác giả
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Authors.Find(id);
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Update(author);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // Xóa tác giả
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Authors.Find(id);
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var author = _db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Chi tiết tác giả
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var author = _db.Authors.Find(id);
            return View(author);
        }
    }
}
