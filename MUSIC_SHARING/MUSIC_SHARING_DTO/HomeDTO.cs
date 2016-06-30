using MUSIC_SHARING.MUSIC_SHARING.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MUSIC_SHARING.MUSIC_SHARING_DTO
{
    public class HomeDTO
    {
        public List<SongDTO> TopFPT { get; set; }
        public List<SongDTO> TopWorld { get; set; }
        public List<SongDTO> UserDefaultList { get; set; }
    }
}