using System.Collections.Generic;

namespace Domain
{
    public class Festival
    {
        public int FestivalId { get; set; }

        public string FestivalName { get; set; } = default!;
        
        
        public ICollection<Dj>? FestivalDjs { get; set; }
    }
}