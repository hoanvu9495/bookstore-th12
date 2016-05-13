using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Entities;
using BookStore.Code;
using PagedList;
using PagedList.Mvc;

namespace BookStore.DAO
{
    public class BookDAO
    {
        DBContent db;
        public BookDAO()
        {
            db = new DBContent();
        }
        public IEnumerable<BSSACH> listBook(int pageNumber, int pageSize )
        {
            var ret = db.BSSACHes.OrderBy(n=>n.GIABIA).ToPagedList(pageNumber,pageSize);
            return ret;
        }
        public static IQueryable<BSSACH> listHot(int count)
        {
            DBContent data = new DBContent();
            var ret = (from s in data.BSSACHes
                       select s).Take(count);
            return ret;
        }
        public static IQueryable<BSSACH> listSachMoi( int count)
        {
            DBContent data = new DBContent();
            var ret = data.BSSACHes.Take(count).OrderByDescending(n => n.MASACH);
            return ret;
        }
        //Lấy thông tin chi tiết của 1 cuốn sách
        public static BookCode chiTietSach(int MaSach)
        {
            DBContent data = new DBContent();
            BSSACH sach = data.BSSACHes.Single(n => n.MASACH == MaSach);
            BookCode BC = new BookCode();
            BC.MaSach = sach.MASACH;
            BC.TenSach = sach.TENSACH;
            BC.TenLoai = data.BSLOAIs.Single(n => n.MALOAI == sach.MALOAI).TENLOAI;
            BC.TenNXB = data.BSNXBs.Single(n => n.MANXB == sach.MANXB).TENNXB;
            BC.TenTacGia = data.BSTACGIAs.Single(n => n.MATG == sach.MATG).HOTEN;
            BC.SoLuong = sach.SOLUONG;
            BC.NgayXB = sach.NGXB;
            BC.GiaBia = (Int32)sach.GIABIA;
            BC.TrongLuong = sach.TRONGLUONG == null ? 0 : (double)sach.TRONGLUONG;
            BC.KhoGiay = sach.KHO;
            BC.AnhBia = sach.BIA;
            BC.GioiThieu = sach.GIOITHIEU;
            BC.KhuyenMai = (data.BSCTKMs.SingleOrDefault(n => n.MASACH == sach.MASACH) == null) ? 0 : data.BSCTKMs.SingleOrDefault(n => n.MASACH == sach.MASACH).PTKM;
            BC.SoTrang = sach.SOTRANG;
            return BC;
        }
        public static bool findMaSach(int MaSach)
        {
            DBContent data = new DBContent();
            var ret = data.BSSACHes.SingleOrDefault(n => n.MASACH == MaSach);
            return ret == null ? false : true;
        }
        
    }
}