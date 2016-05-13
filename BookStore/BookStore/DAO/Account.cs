using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Entities;
using System.Data.SqlClient;
using System.Collections;

namespace BookStore.DAO
{
    public class Account
    {
        private DBContent myDB = null;
        public Account()
        {
            myDB = new DBContent();
        }
        public bool Login(string userName, string passWord)
        {
            object[] sqlParams=
            {
                new SqlParameter("@USERNAME",userName),
                new SqlParameter("@PASSWORD",passWord),
            };
            var res = myDB.Database.SqlQuery<bool>("SP_ACCOUNT_LOGIN  @USERNAME, @PASSWORD", sqlParams).SingleOrDefault();
            return res;
        }
        public int getRank(string userName)
        {
            var ret=myDB.BSUSERs.Where(n => n.TAIKHOAN == userName).Select(n => n.USRANK).SingleOrDefault();
            int rank = ret==null?0:int.Parse(ret.ToString());
            return rank;
        }
        public string getAvatar(string userName)
        {
            var ret = myDB.BSUSERs.Where(n => n.TAIKHOAN == userName).Select(n => n.avatar).SingleOrDefault();
            return ret;
        }
        public int getId(string userName)
        {
            var ret = myDB.BSUSERs.Where(n => n.TAIKHOAN == userName).Select(n => n.MAUSR).SingleOrDefault();
            return ret;
        }
        public static int findIdByUserName(string userName)
        {
            DBContent myDB = new DBContent();
            var ret = myDB.BSUSERs.Where(n => n.TAIKHOAN == userName).Select(n => n.MAUSR).SingleOrDefault();
            int MaUser=0;
            if (ret!=null)
            {
                 MaUser =int.Parse(ret.ToString());
            }
            return MaUser;
        }
    }
}