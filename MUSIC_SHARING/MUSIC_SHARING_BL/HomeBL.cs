using MUSIC_SHARING.MUSIC_SHARING.BL;
using MUSIC_SHARING.MUSIC_SHARING.DA;
using MUSIC_SHARING.MUSIC_SHARING_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MUSIC_SHARING.MUSIC_SHARING_BL
{
    public class HomeBL
    {
        public HomeDTO Initialize()
        {
            SongBL songBL = new SongBL();
            HomeDTO homeDTO = new HomeDTO();
            UserBL userBL = new UserBL();
            string userName = GetUserName(songBL);

            if (!userBL.CheckUser(userName))
            {
                // Insert new user
                userBL.InsertUser(userName);
            }
            else
            {
                homeDTO.UserDefaultList = songBL.GetDefaultList(userName);
            }

            homeDTO.TopFPT = songBL.SelectTopFptSong();
            homeDTO.TopWorld = songBL.SelectTopWorldSong();
            return homeDTO;
        }

        public string GetUserName(SongBL songBL)
        {
            return songBL.GetUserAccount(HttpContext.Current.Request.LogonUserIdentity.Name);
        }

       


    }
}