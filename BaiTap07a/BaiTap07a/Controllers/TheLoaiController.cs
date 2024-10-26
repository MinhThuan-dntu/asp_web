using BaiTap07a.Data;
using BaiTap07a.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap07a.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var theloai = _db.Loai.ToList();
            ViewBag.TheLoai = theloai;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.Loai.Add(theloai);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.Loai.Find(id);
            return View(theloai);
        }

        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.Loai.Update(theloai);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.Loai.Find(id);
            return View(theloai);
        }


        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.Loai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.Loai.Remove(theloai);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.Loai.Find(id);
            return View(theloai);
        }

        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var theloai = _db.Loai
                   .Where(tl => tl.Name.Contains(searchString))
                   .ToList();

                ViewBag.SearchString = searchString;
                ViewBag.TheLoai = theloai;
            }
            else
            {
                var theloai = _db.Loai.ToList();
                ViewBag.Loai = theloai;
            }
            return View("Index");
        }

    }

}