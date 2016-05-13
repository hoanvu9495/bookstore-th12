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
    public class ChiTietKhuyenMaiController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /ChiTietKhuyenMai/
        public ActionResult Index(int id)
        {
            var bsctkms = db.BSCTKMs.Where(a=>a.MAKM==id).Include(b => b.BSKHUYENMAI).Include(b => b.BSSACH);
            return View(bsctkms.ToList());
        }

        // GET: /ChiTietKhuyenMai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCTKM bsctkm = db.BSCTKMs.Find(id);
            if (bsctkm == null)
            {
                return HttpNotFound();
            }
            return View(bsctkm);
        }

        // GET: /ChiTietKhuyenMai/Create
        public ActionResult Create()
        {
            ViewBag.MAKM = new SelectList(db.BSKHUYENMAIs, "MAKM", "TENKM");
            ViewBag.MASACH = new SelectList(db.BSSACHes, "MASACH", "TENSACH");
            return View();
        }

        // POST: /ChiTietKhuyenMai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MAKM,MASACH,PTKM,ISDELETE")] BSCTKM bsctkm)
        {
            if (ModelState.IsValid)
            {
                db.BSCTKMs.Add(bsctkm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKM = new SelectList(db.BSKHUYENMAIs, "MAKM", "TENKM", bsctkm.MAKM);
            ViewBag.MASACH = new SelectList(db.BSSACHes, "MASACH", "TENSACH", bsctkm.MASACH);
            return View(bsctkm);
        }

        // GET: /ChiTietKhuyenMai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCTKM bsctkm = db.BSCTKMs.Find(id);
            if (bsctkm == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKM = new SelectList(db.BSKHUYENMAIs, "MAKM", "TENKM", bsctkm.MAKM);
            ViewBag.MASACH = new SelectList(db.BSSACHes, "MASACH", "TENSACH", bsctkm.MASACH);
            return View(bsctkm);
        }

        // POST: /ChiTietKhuyenMai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MAKM,MASACH,PTKM,ISDELETE")] BSCTKM bsctkm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bsctkm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKM = new SelectList(db.BSKHUYENMAIs, "MAKM", "TENKM", bsctkm.MAKM);
            ViewBag.MASACH = new SelectList(db.BSSACHes, "MASACH", "TENSACH", bsctkm.MASACH);
            return View(bsctkm);
        }

        // GET: /ChiTietKhuyenMai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCTKM bsctkm = db.BSCTKMs.Find(id);
            if (bsctkm == null)
            {
                return HttpNotFound();
            }
            return View(bsctkm);
        }

        // POST: /ChiTietKhuyenMai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSCTKM bsctkm = db.BSCTKMs.Find(id);
            db.BSCTKMs.Remove(bsctkm);
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
