using MUSIC_SHARING.MUSIC_SHARING.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MUSIC_SHARING.MUSIC_SHARING.BL
{
    public class UserBL
    {
        public bool CheckUser(string user)
        {
            SongDA songDA = new SongDA();
            DataTable dt = null;
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", user));

            dt = songDA.GetData("CHECK_USER_EXIST", list);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertUser(string user)
        {
            SongDA songDA = new SongDA();
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", user));
            songDA.UpdateData("INSERT_USER", list);
        }
    }
}