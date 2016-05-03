using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.DAO;
using BookStore.Entities;

namespace BookStore.Controllers
{
    public class DangKyController : Controller
    {
        private DBContent db = new DBContent();
        //
        // GET: /DangKy/
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult reg(string HoTen, DateTime NgSinh, string GT, string Email, string Sdt, string DiaChi, string TaiKhoan, string MatKhau)
        {
            UserDAO dao = new UserDAO();
            dao.InsertUser(HoTen, NgSinh, GT, Email, Sdt, DiaChi, TaiKhoan, MatKhau);
            ViewBag.DangKy = "Bạn đã đăng ký thành công!"+HoTen;
            return View(ViewBag);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "MAUSR,HOTEN,NGSINH,GT,EMAIL,SDT,DIACHI,TAIKHOAN,MATKHAU")] BSUSER bsuser)
        {
            if (ModelState.IsValid)
            {
                db.BSUSERs.Add(bsuser);
                db.SaveChanges();
                ViewBag.mes = bsuser.TAIKHOAN;
                return RedirectToAction("Index","Home",ViewBag);
            }

            return View(bsuser);
        }
	}
}