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
    public class LoaiSachController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /LoaiSach/
        public ActionResult Index()
        {
            return View(db.BSLOAIs.ToList());
        }

        // GET: /LoaiSach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSLOAI bsloai = db.BSLOAIs.Find(id);
            if (bsloai == null)
            {
                return HttpNotFound();
            }
            return View(bsloai);
        }

        // GET: /LoaiSach/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /LoaiSach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MALOAI,TENLOAI,GHICHU")] BSLOAI bsloai)
        {
            if (ModelState.IsValid)
            {
                db.BSLOAIs.Add(bsloai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bsloai);
        }

        // GET: /LoaiSach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSLOAI bsloai = db.BSLOAIs.Find(id);
            if (bsloai == null)
            {
                return HttpNotFound();
            }
            return View(bsloai);
        }

        // POST: /LoaiSach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MALOAI,TENLOAI,GHICHU")] BSLOAI bsloai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bsloai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bsloai);
        }

        // GET: /LoaiSach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSLOAI bsloai = db.BSLOAIs.Find(id);
            if (bsloai == null)
            {
                return HttpNotFound();
            }
            return View(bsloai);
        }

        // POST: /LoaiSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSLOAI bsloai = db.BSLOAIs.Find(id);
            db.BSLOAIs.Remove(bsloai);
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
