using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Entities;

namespace BookStore.Controllers
{
    public class TacGiaController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /TacGia/
        public ActionResult Index()
        {
            return View(db.BSTACGIAs.ToList());
        }

        // GET: /TacGia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSTACGIA bstacgia = db.BSTACGIAs.Find(id);
            if (bstacgia == null)
            {
                return HttpNotFound();
            }
            return View(bstacgia);
        }

        // GET: /TacGia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TacGia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MATG,HOTEN,GT,GIOITHIEU,BUTDANH,NGSINH")] BSTACGIA bstacgia)
        {
            if (ModelState.IsValid)
            {
                db.BSTACGIAs.Add(bstacgia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bstacgia);
        }

        // GET: /TacGia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSTACGIA bstacgia = db.BSTACGIAs.Find(id);
            if (bstacgia == null)
            {
                return HttpNotFound();
            }
            return View(bstacgia);
        }

        // POST: /TacGia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MATG,HOTEN,GT,GIOITHIEU,BUTDANH,NGSINH")] BSTACGIA bstacgia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bstacgia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bstacgia);
        }

        // GET: /TacGia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSTACGIA bstacgia = db.BSTACGIAs.Find(id);
            if (bstacgia == null)
            {
                return HttpNotFound();
            }
            return View(bstacgia);
        }

        // POST: /TacGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSTACGIA bstacgia = db.BSTACGIAs.Find(id);
            db.BSTACGIAs.Remove(bstacgia);
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
