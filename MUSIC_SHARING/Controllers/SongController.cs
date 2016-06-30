using MUSIC_SHARING.MUSIC_SHARING.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MUSIC_SHARING.Controllers
{
    public class SongController : Controller
    {
        //
        // GET: /Song/
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public JsonResult UploadMusic(IEnumerable<HttpPostedFileBase> files)
        {
            SongBL songBL = new SongBL();
            bool result = songBL.InsertSong(files);
            string message = String.Empty;
            if (result)
            {
                message = "OK, ngon rồi";
            }
            else
            {
                message = "Đéo được, làm lại đi !";
            }

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Test()
        {
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSong(string songID)
        {
            SongBL songBL = new SongBL();

            string path = songBL.GetSongUrlByID(songID);

            return File(path, "audio/mp3");
        }


        [HttpPost]
        public ActionResult AddToDefaultList(string songID)
        {
            SongBL songBL = new SongBL();
            songBL.AddToDefaultList(songID);

            return Json("Ok man, add xong roi", JsonRequestBehavior.AllowGet);
        }

       
    }


}