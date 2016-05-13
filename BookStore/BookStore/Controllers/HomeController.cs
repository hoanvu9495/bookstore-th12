using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Entities;
using BookStore.DAO;
using BookStore.Code;
using PagedList;
using PagedList.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Index(int? page)
        {
            //tạo môt biến số sản phẩm trên trang
            int pageSize = 9;
            //Số trang
            int pageNumber = (page ?? 1);
            BookDAO dao = new BookDAO();
            var lstBooks=dao.listBook(pageNumber,pageSize);
            return View(lstBooks);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult Index(LoginModel model)
        //{
        //    var result = new Account().Login(model.UserName, model.Password);
        //    if (result && ModelState.IsValid)
        //    {
        //        int rank = Account.getRank(model.UserName);
        //        SessionHelper.SetSession(new UserSession() { userName = model.UserName ,userRank= rank});

        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
        //    }
        //    return View();
        //}

        public ActionResult Logout()
        {
            SessionHelper.RemoveSession();
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Home");
        }

	}
}