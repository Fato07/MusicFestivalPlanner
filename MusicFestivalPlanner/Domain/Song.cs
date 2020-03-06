using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Song
    {
        public int SongId { get; set; }

        public string SongName { get; set; } = default!;
        
        [Display(Name="ReleaseDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Duration")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH-mm-ss} ", ApplyFormatInEditMode = true)]
        public DateTime Duration  { get; set; }

        public ICollection<DjSong>? DjSongs{ get; set; }

        public ICollection<PerformerSong>? PerformerSongs { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        
        public Genre? Genre { get; set; }
    }
    
}