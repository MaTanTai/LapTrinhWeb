using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap04.Views.Nhom
{
    public class TrangController : Controller
    {
        // GET: TrangController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrangController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrangController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
