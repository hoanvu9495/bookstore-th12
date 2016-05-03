using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Entities;

namespace BookStore.DAO
{
    
    public class UserDAO
    {
        DBContent db;
        public UserDAO()
        {
            db = new DBContent();
        }

        public int InsertUser(string HoTen, DateTime NgSinh,string GT, string Email, string Sdt, string DiaChi,string TaiKhoan, string MatKhau)
        {
            BSUSER user = new BSUSER();
            user.HOTEN = HoTen;
            user.NGSINH = NgSinh;
            user.GT = GT;
            user.EMAIL = Email;
            user.SDT = Sdt;
            user.DIACHI = DiaChi;
            user.TAIKHOAN = TaiKhoan;
            user.MATKHAU = MatKhau;
            db.BSUSERs.Add(user);
            db.SaveChanges();
            return user.MAUSR;
        }
        public IEnumerable<BSUSER> ListUser()
        {
            var res = (from s in db.BSUSERs select s);
            return res;
        }
        public void UpdateUser(BSUSER officeTmp)
        {
            BSUSER user = db.BSUSERs.Find(officeTmp.MAUSR);
            if (user != null)
            {
                user.HOTEN = officeTmp.HOTEN;
                user.NGSINH = officeTmp.NGSINH;
                user.GT = officeTmp.GT;
                user.EMAIL = officeTmp.EMAIL;
                user.SDT = officeTmp.SDT;
                user.DIACHI = officeTmp.DIACHI;
                user.TAIKHOAN = officeTmp.TAIKHOAN;
                user.MATKHAU = officeTmp.MATKHAU;
                db.SaveChanges();
            }
        }
        public void DeleteUser(BSUSER userTmp)
        {
            BSUSER user = db.BSUSERs.Find(userTmp.MAUSR);
            if (user != null)
            {
                db.BSUSERs.Remove(user);
                db.SaveChanges();
            }

        }
        public BSUSER FindOfficeByICode(int Code)
        {
            return db.BSUSERs.Find(Code);
        }
    }
    
}