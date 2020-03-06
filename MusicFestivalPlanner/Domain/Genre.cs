using System.Collections.Generic;

namespace Domain
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = default!;

        public ICollection<Song>? Songs { get; set; }
    }
}