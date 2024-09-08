using Microsoft.AspNetCore.Mvc;

namespace baitap4.Controllers
{
    public class Thuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Vu Minh Thuan";
            ViewBag.MSSV = "1822040780";
            ViewData["Nam"] = "Năm 2004";
            return View();
        }
    }
}
