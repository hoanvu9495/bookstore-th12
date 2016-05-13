﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.DAO;
using BookStore.Code;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginModel model)
        {
            Account acc = new Account();
            var result = acc.Login(model.UserName, model.Password);
            if (result && ModelState.IsValid)
            {
                //var rank = acc.getRank(model.UserName);
                //SessionHelper.SetSession(new UserSession() { userName = model.UserName, userRank= rank  });
                SessionHelper.SetSession(new UserSession() { userName = model.UserName , userRank= acc.getRank(model.UserName), avatar=acc.getAvatar(model.UserName)});
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View();
        }
	}
}