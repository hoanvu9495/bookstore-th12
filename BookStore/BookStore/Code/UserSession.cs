using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Code
{
    [Serializable]
    public class UserSession
    {
        public string userName { set; get; }
        public int userRank { set; get; }
        public string avatar { set; get; }
    }
}