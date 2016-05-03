using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Entities;

namespace BookStore.DAO
{
    public class NhaXuatBanDAO
    {
        DBContent db;
        public NhaXuatBanDAO()
        {
            db = new DBContent();
        }
        public static IEnumerable<BSNXB> ListNXB()
        {
            DBContent db = new DBContent();
            var ret = db.BSNXBs.ToList();
            return ret;
        }
    }
}