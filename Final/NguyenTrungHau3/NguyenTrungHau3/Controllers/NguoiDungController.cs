using NguyenTrungHau3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenTrungHau3.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        MyDataDataContext data = new MyDataDataContext();

       

        public ActionResult NguoiDung()
        {
            var all_nguoidung = from ss in data.KhachHangs select ss;
            return View(all_nguoidung);
        }

        public ActionResult Detail(int id)
        {
            var D_nguoidung = data.KhachHangs.Where(m => m.makh == id).First();
            return View(D_nguoidung);
        }

        public ActionResult Edit(int id)
        {
            var E_khachhang = data.KhachHangs.First(m => m.makh == id);
            return View(E_khachhang);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_khachhang = data.KhachHangs.First(m => m.makh == id);
            var E_hoten = collection["hoten"];
            var E_tendangnhap = collection["tendangnhap"];
            var E_matkhau = collection["matkhau"];
            var E_diachi = collection["diachi"];
            var E_dienthoai = collection["dienthoai"];
            var E_ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
            
            E_khachhang.makh = id;
            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_khachhang.tendangnhap = E_tendangnhap;
                
                E_khachhang.matkhau = E_matkhau;
                E_khachhang.diachi = E_diachi;
                E_khachhang.dienthoai = E_dienthoai;
                UpdateModel(E_khachhang);
                data.SubmitChanges();
                return RedirectToAction("NguoiDung");
            }
            return this.Edit(id);
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]

        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["hoten"];
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            var email = collection["email"];
            var diachi = collection["diachi"];
            var dienthoai = collection["dienthoai"];
            var ngaysinh  = Convert.ToDateTime(collection["ngaysinh"]);

            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMKXN"] = "Phải nhập mật khẩu xác nhận!";
            }
            else
            {
                if(!matkhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau";
                }
                else
                {
                    kh.hoten = hoten;
                    kh.tendangnhap = tendangnhap;
                    kh.matkhau = matkhau;
                    kh.email = email;
                    kh.diachi = diachi;
                    kh.dienthoai = dienthoai;
                    kh.ngaysinh = ngaysinh;
                    data.KhachHangs.InsertOnSubmit(kh);
                    data.SubmitChanges();
                    return RedirectToAction("DangNhap");
                }
            }
            return this.DangKy();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            KhachHang kh = data.KhachHangs.SingleOrDefault(n => n.tendangnhap == tendangnhap && n.matkhau == matkhau);
            if(kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                Session["TaiKhoan"] = kh;
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}