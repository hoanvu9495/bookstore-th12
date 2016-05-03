using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Entities;

namespace BookStore.Controllers.Admin
{
    public class UserController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /User/
        public ActionResult Index()
        {
            return View(db.BSUSERs.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSUSER bsuser = db.BSUSERs.Find(id);
            if (bsuser == null)
            {
                return HttpNotFound();
            }
            return View(bsuser);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MAUSR,HOTEN,NGSINH,GT,EMAIL,SDT,DIACHI,TAIKHOAN,MATKHAU")] BSUSER bsuser)
        {
            if (ModelState.IsValid)
            {
                db.BSUSERs.Add(bsuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bsuser);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSUSER bsuser = db.BSUSERs.Find(id);
            if (bsuser == null)
            {
                return HttpNotFound();
            }
            return View(bsuser);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MAUSR,HOTEN,NGSINH,GT,EMAIL,SDT,DIACHI,TAIKHOAN,MATKHAU")] BSUSER bsuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bsuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bsuser);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSUSER bsuser = db.BSUSERs.Find(id);
            if (bsuser == null)
            {
                return HttpNotFound();
            }
            return View(bsuser);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSUSER bsuser = db.BSUSERs.Find(id);
            db.BSUSERs.Remove(bsuser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
