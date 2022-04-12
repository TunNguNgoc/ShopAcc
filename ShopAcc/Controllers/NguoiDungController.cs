using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAcc.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        dbShopAccDataContext data = new dbShopAccDataContext();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["hoten"];
            var tedanghap = collection["tendangnhap"];
            var maykhau = collection["matkhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            var email = collection["email"];
            var dienthoai = collection["dienthoai"];
            var ngaysinh = collection["ngaysinh"];
            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMKXN"] = "Phải nhập mật khẩu khẩu khác nhận!";
            }
            else
            {
                if (!maykhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauXacNhan"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau!!";
                }
                else
                {
                    kh.hoten = hoten;
                    kh.tendangnhap = tedanghap;
                    kh.matkhau = maykhau;
                    kh.email = email;
                    kh.ngaysinh = DateTime.Parse(ngaysinh);
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
            if (kh != null)
            {
                ViewBag.ThogBao = "Chúc mừng đăng nhập thành công!";
                Session["TaiKhoan"] = kh;
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng!!";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}