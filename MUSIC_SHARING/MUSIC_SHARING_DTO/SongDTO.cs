using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MUSIC_SHARING.MUSIC_SHARING.DTO
{
    public class SongDTO
    {
        public Int16 SONG_ID { get; set; }
        public string SONG_NAME { get; set; }
        public string ARTIST { get; set; }
        public string ALBUM { get; set; }
        public Int16 DURATION { get; set; }
        public Int16 NUMBER_LISTEN { get; set; }
        public byte WORLD_CHART { get; set; }
        public string UPLOAD_USER { get; set; }
        public DateTime UPLOAD_DATE { get; set; }

        public string GetMinutes()
        {
            int minutes = 0;
            int second = 0;

            minutes = (this.DURATION / 60);
            second = (this.DURATION % 60);
            if (second < 10)
            {
                return minutes.ToString() + ":0" + second.ToString();
            }
            else
            {
                return minutes.ToString() + ":" + second.ToString();
            }

        }
    }
}