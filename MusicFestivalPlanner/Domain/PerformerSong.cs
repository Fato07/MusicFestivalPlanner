using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PerformerSong
    {
        public int PerformerSongId { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; }
        
        public Role? Role { get; set; }

        [Display(Name = "Performer")]
        public int PerformerId { get; set; }
        
        public Performer? Performer { get; set; }

         
        [Display(Name = "Song")]
        public int SongId { get; set; }
       
        public Song? Song { get; set; }
    }
}