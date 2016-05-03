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
    public class DauSachController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /DauSach/
        public ActionResult Index()
        {
            var bssaches = db.BSSACHes.Include(b => b.BSLOAI).Include(b => b.BSNXB).Include(b => b.BSTACGIA);
            return View(bssaches.ToList());
        }

        // GET: /DauSach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSSACH bssach = db.BSSACHes.Find(id);
            if (bssach == null)
            {
                return HttpNotFound();
            }
            return View(bssach);
        }

        // GET: /DauSach/Create
        public ActionResult Create()
        {
            ViewBag.MALOAI = new SelectList(db.BSLOAIs, "MALOAI", "TENLOAI");
            ViewBag.MANXB = new SelectList(db.BSNXBs, "MANXB", "TENNXB");
            ViewBag.MATG = new SelectList(db.BSTACGIAs, "MATG", "HOTEN");
            return View();
        }

        // POST: /DauSach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MASACH,MALOAI,MANXB,TENSACH,MATG,SOLUONG,TRONGLUONG,NGXB,GIABIA,SOTRANG,KHO,BIA,GIOITHIEU")] BSSACH bssach)
        {
            if (ModelState.IsValid)
            {
                db.BSSACHes.Add(bssach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MALOAI = new SelectList(db.BSLOAIs, "MALOAI", "TENLOAI", bssach.MALOAI);
            ViewBag.MANXB = new SelectList(db.BSNXBs, "MANXB", "TENNXB", bssach.MANXB);
            ViewBag.MATG = new SelectList(db.BSTACGIAs, "MATG", "HOTEN", bssach.MATG);
            return View(bssach);
        }

        // GET: /DauSach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSSACH bssach = db.BSSACHes.Find(id);
            if (bssach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALOAI = new SelectList(db.BSLOAIs, "MALOAI", "TENLOAI", bssach.MALOAI);
            ViewBag.MANXB = new SelectList(db.BSNXBs, "MANXB", "TENNXB", bssach.MANXB);
            ViewBag.MATG = new SelectList(db.BSTACGIAs, "MATG", "HOTEN", bssach.MATG);
            return View(bssach);
        }

        // POST: /DauSach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MASACH,MALOAI,MANXB,TENSACH,MATG,SOLUONG,TRONGLUONG,NGXB,GIABIA,SOTRANG,KHO,BIA,GIOITHIEU")] BSSACH bssach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bssach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MALOAI = new SelectList(db.BSLOAIs, "MALOAI", "TENLOAI", bssach.MALOAI);
            ViewBag.MANXB = new SelectList(db.BSNXBs, "MANXB", "TENNXB", bssach.MANXB);
            ViewBag.MATG = new SelectList(db.BSTACGIAs, "MATG", "HOTEN", bssach.MATG);
            return View(bssach);
        }

        // GET: /DauSach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSSACH bssach = db.BSSACHes.Find(id);
            if (bssach == null)
            {
                return HttpNotFound();
            }
            return View(bssach);
        }

        // POST: /DauSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSSACH bssach = db.BSSACHes.Find(id);
            db.BSSACHes.Remove(bssach);
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
