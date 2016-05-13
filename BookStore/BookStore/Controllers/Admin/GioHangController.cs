using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Entities;
using BookStore.Code;
using BookStore.DAO;
namespace BookStore.Controllers
{
    public class GioHangController : Controller
    {
        private DBContent db = new DBContent();

        // GET: /GioHang/
        public ActionResult Index()
        {
            var bsdonhangs = db.BSDONHANGs.Include(b => b.BSUSER);
            return View(bsdonhangs.ToList());
        }

        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại => khởi tạo list giỏ hàng(session GioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int MaSach, string strURL)
        {

            BSSACH sach = db.BSSACHes.SingleOrDefault(n => n.MASACH == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sách có tồn tại trong session["GioHang"] chưa?
            GioHang SanPham = lstGioHang.Find(n => n.MaSach == MaSach);
            if (SanPham == null)
            {
                SanPham = new GioHang(MaSach);
                lstGioHang.Add(SanPham);
                Code.GioHang.TongSoSanPham++;
                return Redirect(strURL);

            }
            else
            {
                SanPham.SoLuong++;

                return Redirect(strURL);
            }

        }
        //Cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(int MaSach, FormCollection f)
        {
            BSSACH sach = db.BSSACHes.SingleOrDefault(n => n.MASACH == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang SanPham = lstGioHang.SingleOrDefault(n => n.MaSach == MaSach);
            if (SanPham != null)
            {
                SanPham.SoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaSanPham(int MaSach)
        {
            BSSACH sach = db.BSSACHes.SingleOrDefault(n => n.MASACH == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang SanPham = lstGioHang.SingleOrDefault(n => n.MaSach == MaSach);
            if (SanPham != null)
            {
                lstGioHang.RemoveAll(n => n.MaSach == SanPham.MaSach);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            //if (Session["GioHang"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.SoLuong);
            }
            return iTongSoLuong;
        }
        private int TongSanPham()
        {
            int iTongSanPham = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSanPham = lstGioHang.Count;
            }
            return iTongSanPham;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        public ActionResult gioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        // GET: /GioHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSDONHANG bsdonhang = db.BSDONHANGs.Find(id);
            if (bsdonhang == null)
            {
                return HttpNotFound();
            }
            return View(bsdonhang);
        }

        // GET: /GioHang/Create
        public ActionResult Create()
        {
            ViewBag.MAKHACHHANG = new SelectList(db.BSUSERs, "MAUSR", "HOTEN");
            return View();
        }

        // POST: /GioHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public ActionResult InsertDonHang()
        {
            if (Session["GioHang"] == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = new List<GioHang>();
            lstGioHang = (List<GioHang>)Session["GioHang"];
            //Tạo một đơn hàng mới
            BSDONHANG DonHang = new BSDONHANG();
            if (ModelState.IsValid)
            {
                DonHang.MAKHACHHANG = Account.findIdByUserName(SessionHelper.GetSession().userName);
                DonHang.NGDAT = DateTime.Now;
                DonHang.NGGIAO = DateTime.Now.AddDays(3);
                DonHang.TINHTRANGGH = false;
                DonHang.TONGTIEN = Int32.Parse(lstGioHang.Sum(n => n.ThanhTien).ToString());
                db.BSDONHANGs.Add(DonHang);
                db.SaveChanges();
            }



            foreach (var item in lstGioHang)
            {
                BSCTDH ctDonHang = new BSCTDH();
                ctDonHang.MADH = DonHang.MADH;
                ctDonHang.MASACH = item.MaSach;
                ctDonHang.SOLUONG = item.SoLuong;
                ctDonHang.DONGIA = item.DonGia;
                ctDonHang.KM = item.KhuyenMai;
                ctDonHang.THANHTIEN = int.Parse(item.ThanhTien.ToString());
                db.BSCTDHs.Add(ctDonHang);
                db.SaveChanges();
            }
            Session["GioHang"] = null;
            return RedirectToAction("GioHang", "GioHang");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADH,MAKHACHHANG,NGDAT,NGGIAO,DATHANHTOAN,TINHTRANGGH")] BSDONHANG bsdonhang)
        {
            if (ModelState.IsValid)
            {
                db.BSDONHANGs.Add(bsdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKHACHHANG = new SelectList(db.BSUSERs, "MAUSR", "HOTEN", bsdonhang.MAKHACHHANG);
            return View(bsdonhang);
        }

        // GET: /GioHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSDONHANG bsdonhang = db.BSDONHANGs.Find(id);
            if (bsdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKHACHHANG = new SelectList(db.BSUSERs, "MAUSR", "HOTEN", bsdonhang.MAKHACHHANG);
            return View(bsdonhang);
        }

        // POST: /GioHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADH,MAKHACHHANG,NGDAT,NGGIAO,DATHANHTOAN,TINHTRANGGH")] BSDONHANG bsdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bsdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKHACHHANG = new SelectList(db.BSUSERs, "MAUSR", "HOTEN", bsdonhang.MAKHACHHANG);
            return View(bsdonhang);
        }

        // GET: /GioHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BSDONHANG bsdonhang = db.BSDONHANGs.Find(id);
            if (bsdonhang == null)
            {
                return HttpNotFound();
            }
            return View(bsdonhang);
        }

        // POST: /GioHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BSDONHANG bsdonhang = db.BSDONHANGs.Find(id);
            IEnumerable<BSCTDH> iEdonhang = db.BSCTDHs.Where(n=>n.MADH==id);
            db.BSCTDHs.RemoveRange(iEdonhang);
            db.SaveChanges();
            db.BSDONHANGs.Remove(bsdonhang);
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
