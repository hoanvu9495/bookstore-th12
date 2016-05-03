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
    public class NXBController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /NXB/
        public ActionResult Index()
        {
            return View(db.BSNXBs.ToList());
        }

        // GET: /NXB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSNXB bsnxb = db.BSNXBs.Find(id);
            if (bsnxb == null)
            {
                return HttpNotFound();
            }
            return View(bsnxb);
        }

        // GET: /NXB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /NXB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MANXB,TENNXB,SDT,DIACHI")] BSNXB bsnxb)
        {
            if (ModelState.IsValid)
            {
                db.BSNXBs.Add(bsnxb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bsnxb);
        }

        // GET: /NXB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSNXB bsnxb = db.BSNXBs.Find(id);
            if (bsnxb == null)
            {
                return HttpNotFound();
            }
            return View(bsnxb);
        }

        // POST: /NXB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MANXB,TENNXB,SDT,DIACHI")] BSNXB bsnxb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bsnxb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bsnxb);
        }

        // GET: /NXB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSNXB bsnxb = db.BSNXBs.Find(id);
            if (bsnxb == null)
            {
                return HttpNotFound();
            }
            return View(bsnxb);
        }

        // POST: /NXB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSNXB bsnxb = db.BSNXBs.Find(id);
            db.BSNXBs.Remove(bsnxb);
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
