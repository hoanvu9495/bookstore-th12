using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Entities;

namespace BookStore.DAO
{
    public class AdminDAO
    {
        DBContent db;
        public AdminDAO()
        {
            db=new DBContent();
        }
        //Lấy user mới đăng ký
        public static IEnumerable<BSUSER> GetUserUpdate()
        {
            DBContent db = new DBContent();
            var ret = db.BSUSERs.Take(5).OrderByDescending(n => n.MAUSR);
            return ret;
        }
        //Lấy đơn hàng mới đặt
        public static IEnumerable<BSDONHANG> GetDonHangUpdate()
        {
            DBContent db = new DBContent();
            var ret = db.BSDONHANGs.Take(5).OrderByDescending(n => n.MADH);
            return ret;
        }
        //Lấy đầu sách mới cập nhật
        public static IEnumerable<BSSACH> GetSachUpdate()
        {
            DBContent db = new DBContent();
            var ret = db.BSSACHes.Take(5).OrderByDescending(n => n.MASACH);
            return ret;
        }
        //Lấy nhà xuất bản mới cập nhật
        public static IEnumerable<BSNXB> GetNXBUpdate()
        {
            DBContent db = new DBContent();
            var ret = db.BSNXBs.Take(5).OrderByDescending(n => n.MANXB);
            return ret;
        }
        //Lấy tác giả mới cập nhật
        public static IEnumerable<BSTACGIA> GetTacGiaUpdate()
        {
            DBContent db = new DBContent();
            var ret = db.BSTACGIAs.Take(5).OrderByDescending(n => n.MATG);
            return ret;
        }
        //Khuyến mại mới cập nhật
        public static IEnumerable<BSKHUYENMAI> GetKhuyenMaiUpdate()
        {
            DBContent db = new DBContent();
            var ret = db.BSKHUYENMAIs.Take(5).OrderByDescending(n => n.MAKM);
            return ret;
        }
    }
}