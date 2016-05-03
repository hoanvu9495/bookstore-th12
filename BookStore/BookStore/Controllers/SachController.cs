using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.DAO;
using BookStore.Entities;
using BookStore.Code;

namespace BookStore.Controllers
{
    public class SachController : Controller
    {
        //
        // GET: /Sach/
        
        public ViewResult xemChiTiet(int MaSach)
        {
            if (!BookDAO.findMaSach(MaSach))
            {
                Response.StatusCode = 404;
                return null;
            }
            BookCode sach=BookDAO.chiTietSach(MaSach);
            return View(sach);
        }
    }
}