using BaiTapKT01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKT01.Controllers
{
	public class TaiKhoanController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult DangKy(TaiKhoanViewModel taiKhoan)
		{
			if (taiKhoan.Username != null)
			{
				return Content(taiKhoan.Username);
			}
			return View(taiKhoan);
		}
		public IActionResult BaiTap2()
		{
			var sanpham = new SanPhamViewModel()
			{
				TenSP = "Trà",
				GiaBan = 1000,
				AnhMoTa = "/images/p1.jpg"
			};
			return View(sanpham);
		}
	}
}
