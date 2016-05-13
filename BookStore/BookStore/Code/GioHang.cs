using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Entities;
using BookStore.DAO;
using BookStore.Code;
namespace BookStore.Code
{
    public class GioHang
    {
        DBContent db;
        public int MaSach { set; get; }
        public string TenSach { set; get; }
        public string AnhBia { set; get; }
        public int DonGia { set; get; }
        public int SoLuong { set; get; }
        public int KhuyenMai { set; get; }
        public static int TongSoSanPham { set; get; }
        public double ThanhTien
        {
            set
            {
                ThanhTien = value;
            }
            get
            {
                if (KhuyenMai == 0)
                {
                    return SoLuong * DonGia;
                }
                else
                {
                    return SoLuong * DonGia * KhuyenMai;
                }

            }
        }
        //Hàm tạo
        public GioHang(int MaSach)
        {
            db = new DBContent();
            this.MaSach = MaSach;
            BSSACH sach = db.BSSACHes.Single(n => n.MASACH == MaSach);
            TenSach = sach.TENSACH;
            AnhBia = sach.BIA;
            DonGia = sach.GIABIA;
            BSCTKM khuyenmai = db.BSCTKMs.SingleOrDefault(n => n.MASACH == MaSach);
            KhuyenMai = (khuyenmai == null) ? 0 : khuyenmai.PTKM;
            SoLuong = 1;
            TongSoSanPham = 0;
        }
        public static IEnumerable<BSDONHANG> DonHangDaDat()
        {
            DBContent db = new DBContent();
            string userName=SessionHelper.GetSession().userName;
            int mauser= (int)db.BSUSERs.Where(n=>n.TAIKHOAN==userName).Select(n=>n.MAUSR).Single();
            IEnumerable<BSDONHANG> donhang = (from s in db.BSDONHANGs
                                       where s.MAKHACHHANG== mauser
                                       select s);
            return donhang;
        }

    }
}