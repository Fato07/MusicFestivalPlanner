using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class DjSong
    {
        public int DjSongId { get; set; }
        
        [Display(Name = "DJ")]
        public int DjId{ get; set; }
        public Dj? Dj { get; set; }

        [Display(Name = "Song")]
        public int SongId{ get; set; }
        public Song Song { get; set; }
        
    }
}