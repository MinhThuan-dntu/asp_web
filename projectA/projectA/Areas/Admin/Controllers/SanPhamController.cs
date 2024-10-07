using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using projectA.Data;
using projectA.Models;

namespace projectA.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SanPhamController : Controller
    {
        public readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<SanPhamViewModel> SanPham = _db.SanPham.Include("TheLoai").ToList();
            return View(SanPham);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            SanPhamViewModel sp = new SanPhamViewModel();
            IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                });
            ViewBag.DsTheLoai = dstheloai;
            if (id == 0)
            {
                return View(sp);
            }
            else
            {
                sp = _db.SanPham.Include("TheLoai").FirstOrDefault(s => s.Id == id);
                return View(sp);
            }

        }
        [HttpPost]
        public IActionResult Upsert(SanPhamViewModel sp)
        {
            if (ModelState.IsValid)
            {
                if (sp.Id == 0)
                {
                    _db.SanPham.Add(sp);
                }
                else
                {
                    _db.SanPham.Update(sp);

                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sanpham = _db.SanPham.FirstOrDefault(s => s.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.SanPham.Remove(sanpham);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            var sanpham = _db.SanPham.FirstOrDefault(s => s.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.SanPham.Remove(sanpham);
            _db.SaveChanges();
            return Json(new { success = true });

        }
        [HttpGet]
        public IActionResult detai(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var sanpham = _db.SanPham.Find(id);
            return View(sanpham);
        }



    }
}