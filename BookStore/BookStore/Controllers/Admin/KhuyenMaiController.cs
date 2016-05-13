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
    public class KhuyenMaiController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /KhuyenMai/
        public ActionResult Index()
        {
            return View(db.BSKHUYENMAIs.ToList());
        }

        // GET: /KhuyenMai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSKHUYENMAI bskhuyenmai = db.BSKHUYENMAIs.Find(id);
            if (bskhuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(bskhuyenmai);
        }

        // GET: /KhuyenMai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /KhuyenMai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MAKM,TENKM,NGBATDAU,NGKETTHUC,MOTA,ISDELETE")] BSKHUYENMAI bskhuyenmai)
        {
            if (ModelState.IsValid)
            {
                db.BSKHUYENMAIs.Add(bskhuyenmai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bskhuyenmai);
        }

        // GET: /KhuyenMai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSKHUYENMAI bskhuyenmai = db.BSKHUYENMAIs.Find(id);
            if (bskhuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(bskhuyenmai);
        }

        // POST: /KhuyenMai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MAKM,TENKM,NGBATDAU,NGKETTHUC,MOTA,ISDELETE")] BSKHUYENMAI bskhuyenmai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bskhuyenmai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bskhuyenmai);
        }

        // GET: /KhuyenMai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSKHUYENMAI bskhuyenmai = db.BSKHUYENMAIs.Find(id);
            if (bskhuyenmai == null)
            {
                return HttpNotFound();
            }
            return View(bskhuyenmai);
        }

        // POST: /KhuyenMai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSKHUYENMAI bskhuyenmai = db.BSKHUYENMAIs.Find(id);
            db.BSKHUYENMAIs.Remove(bskhuyenmai);
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
