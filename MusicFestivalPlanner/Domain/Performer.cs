using System.Collections.Generic;

namespace Domain
{
    public class Performer
    {
        public int PerformerId { get; set; }
        public string PerformerName { get; set; } = default!;
        public ICollection<PerformerSong>? PerformerSongs { get; set; }
    }
}