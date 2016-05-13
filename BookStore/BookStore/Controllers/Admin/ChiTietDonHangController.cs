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
    public class ChiTietDonHangController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /ChiTietDonHang/
        public ActionResult Index()
        {
            var bsctdhs = db.BSCTDHs.Include(b => b.BSDONHANG).Include(b => b.BSSACH);
            return View(bsctdhs.ToList());
        }

        // GET: /ChiTietDonHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<BSCTDH> bsctdh = db.BSCTDHs.Where(n=>n.MADH==id);
            if (bsctdh == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/ChiTietDonHang/CTDHAdmin.cshtml",bsctdh);
        }

        // GET: /ChiTietDonHang/Create
        public ActionResult Create()
        {
            ViewBag.MADH = new SelectList(db.BSDONHANGs, "MADH", "MADH");
            ViewBag.MASACH = new SelectList(db.BSSACHes, "MASACH", "TENSACH");
            return View();
        }

        // POST: /ChiTietDonHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MADH,MASACH,SOLUONG,DONGIA,KM,THANHTIEN,ISDELETE")] BSCTDH bsctdh)
        {
            if (ModelState.IsValid)
            {
                db.BSCTDHs.Add(bsctdh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MADH = new SelectList(db.BSDONHANGs, "MADH", "MADH", bsctdh.MADH);
            ViewBag.MASACH = new SelectList(db.BSSACHes, "MASACH", "TENSACH", bsctdh.MASACH);
            return View(bsctdh);
        }

        // GET: /ChiTietDonHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCTDH bsctdh = db.BSCTDHs.Find(id);
            if (bsctdh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MADH = new SelectList(db.BSDONHANGs, "MADH", "MADH", bsctdh.MADH);
            ViewBag.MASACH = new SelectList(db.BSSACHes, "MASACH", "TENSACH", bsctdh.MASACH);
            return View(bsctdh);
        }

        // POST: /ChiTietDonHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MADH,MASACH,SOLUONG,DONGIA,KM,THANHTIEN,ISDELETE")] BSCTDH bsctdh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bsctdh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MADH = new SelectList(db.BSDONHANGs, "MADH", "MADH", bsctdh.MADH);
            ViewBag.MASACH = new SelectList(db.BSSACHes, "MASACH", "TENSACH", bsctdh.MASACH);
            return View(bsctdh);
        }

        // GET: /ChiTietDonHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSCTDH bsctdh = db.BSCTDHs.Find(id);
            if (bsctdh == null)
            {
                return HttpNotFound();
            }
            return View(bsctdh);
        }

        // POST: /ChiTietDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSCTDH bsctdh = db.BSCTDHs.Find(id);
            db.BSCTDHs.Remove(bsctdh);
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
