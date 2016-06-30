using MUSIC_SHARING.MUSIC_SHARING.DA;
using MUSIC_SHARING.MUSIC_SHARING.DTO;
using MUSIC_SHARING.MUSIC_SHARING_DTO;
using MUSIC_SHARING;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MUSIC_SHARING.MUSIC_SHARING.BL
{
    public class SongBL
    {

        public bool InsertSong(IEnumerable<HttpPostedFileBase> files)
        {
            SongDA songDA = new SongDA();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SONG_NAME", typeof(string));
            dataTable.Columns.Add("ARTIST", typeof(string));
            dataTable.Columns.Add("ALBUM", typeof(string));
            dataTable.Columns.Add("DURATION", typeof(Int16));
            dataTable.Columns.Add("UPLOAD_USER", typeof(string));
            dataTable.Columns.Add("DIRECTORY_PATH", typeof(string));

            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    // Get file name
                    string fileName = Path.GetFileName(file.FileName);

                    // Get file name with path
                    string path = Resource1.UploadPath + fileName;

                    // Save file to server
                    file.SaveAs(path);

                    // Load info from .mp3 file
                    TagLib.File tagFile = TagLib.File.Create(path);

                    // Create data for datatable
                    dataTable.Rows.Add(
                        tagFile.Tag.Title,
                        tagFile.Tag.Performers[0],
                        tagFile.Tag.Album,
                        tagFile.Properties.Duration.TotalSeconds,
                        this.GetUserAccount(HttpContext.Current.Request.LogonUserIdentity.Name),
                        path);
                }
            }

            // Insert info to database
            List<SqlParameter> listParam = new List<SqlParameter>();

            listParam.Add(new SqlParameter("@SongDataTable", dataTable));

            bool result = songDA.UpdateData("INSERT_SONG", listParam);


            return result;
        }

        public string GetUserAccount(string fullString)
        {
            string userAccount = String.Empty;

            int index = fullString.IndexOf("\\");

            userAccount = fullString.Substring(index + 1);

            return userAccount;
        }


        public List<SongDTO> SelectTopFptSong()
        {
            SongDA songDA = new SongDA();
            DataTable dt = null;

            dt = songDA.GetData("SELECT_TOP_FPT_SONG");

            return EntityHelper<SongDTO>.GetListObject(dt);
        }

        public List<SongDTO> SelectTopWorldSong()
        {
            SongDA songDA = new SongDA();
            DataTable dt = null;

            dt = songDA.GetData("SELECT_TOP_WORLD_SONG");

            return EntityHelper<SongDTO>.GetListObject(dt);
        }



        public string GetSongUrlByID(string songID)
        {
            string path = String.Empty;
            SongDA songDA = new SongDA();
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@SongID", songID));

            DataTable dt = songDA.GetData("SELECT_DIRECTORY_PATH_BY_ID", list);
            path = dt.Rows[0][0].ToString();
            if (String.IsNullOrEmpty(path))
            {
                System.Diagnostics.Debug.WriteLine("FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(path + "*********************");
            }

            return path;

        }

        //public SongDTO GetSongByID(string songID)
        //{
        //    SongDTO songDTO = new SongDTO();
        //    SongDA songDA = new SongDA();
        //    List<SqlParameter> list = new List<SqlParameter>();
        //    list.Add(new SqlParameter("@SongID", songID));


        //    return songDTO;

        //}


        public List<SongDTO> GetDefaultList(string user)
        {
            SongDA songDA = new SongDA();
            DataTable dt = null;
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", user));

            dt = songDA.GetData("SELECT_DEFAULT_LIST",list);

            return EntityHelper<SongDTO>.GetListObject(dt);
        }

        public void AddToDefaultList(string songID)
        {
            SongDA songDA = new SongDA();

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", GetUserAccount(HttpContext.Current.Request.LogonUserIdentity.Name)));
            list.Add(new SqlParameter("@SongID", songID));

            System.Diagnostics.Debug.WriteLine(GetUserAccount(HttpContext.Current.Request.LogonUserIdentity.Name));
            System.Diagnostics.Debug.WriteLine(songID);

            songDA.UpdateData("INSERT_SONG_TO_DEFAULT_LIST", list);
        }
    }
}