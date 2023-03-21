using System;
using NguyenTrungHau3.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenTrungHau3.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index(int ? page)
        {
            if (page == null) page = 1;
            var all_sach = (from s in data.Saches select s).OrderBy(m => m.masach);
            int pageSize = 6;
            int pageNum = page ?? 1;
            return View(all_sach.ToPagedList(pageNum, pageSize));
        }

        public ActionResult Detail(int id)
        {
            var D_sach = data.Saches.Where(m => m.masach == id).First();
            return View(D_sach);
        }

        public ActionResult Edit(int id)
        {
            var E_sach = data.Saches.First(m => m.masach == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sach = data.Saches.First(m => m.masach == id);
            var E_tensach = collection["tensach"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_sach.masach = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sach.tensach = E_tensach;
                E_sach.hinh = E_hinh;
                E_sach.giaban = E_giaban;
                E_sach.ngaycapnhat = E_ngaycapnhat;
                E_sach.soluongton = E_soluongton;
                UpdateModel(E_sach);
                data.SubmitChanges();
                return RedirectToAction("ListSach");
            }
            return this.Edit(id);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}