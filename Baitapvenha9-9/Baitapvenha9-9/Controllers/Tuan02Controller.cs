using Microsoft.AspNetCore.Mvc;

namespace Baitapvenha9_9.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Vu Minh Thuan";
            ViewBag.MSSV = "1822040780";
            ViewBag.Nam =  2004;
            return View();
        }
    }
}
    public class Tuan02Controller : Controller
    {

        public IActionResult MayTinh(int a, int b, string pheptinh)
        {
            double PhepTinh;
            if (pheptinh == "cong")
                PhepTinh = a + b;
            else if (pheptinh == "tru")
                PhepTinh = a - b;
            else if (pheptinh == "nhan")
                PhepTinh = a * b;
            else
                PhepTinh = (double)a / b;
            ViewBag.KetQua = PhepTinh;
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
