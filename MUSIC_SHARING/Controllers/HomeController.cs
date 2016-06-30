using MUSIC_SHARING.MUSIC_SHARING_BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MUSIC_SHARING.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeBL homeBL = new HomeBL();
            return View(homeBL.Initialize());
        }

        //public ActionResult GetSong(string songID)
        //{
        //    //var file = Server.MapPath("~/app_data/test.mp3");
        //    var file2 = @"D:\_MusicCenter\test.mp3";
        //    //System.Diagnostics.Debug.WriteLine(file);
        //    System.Diagnostics.Debug.WriteLine(file2);
        //    return File(file2, "audio/mp3");
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}