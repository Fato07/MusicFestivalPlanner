using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public StatisticsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public int FestivalsCount { get; set; }
        public int PerformerCount { get; set; }
        public int DjCount { get; set; }
        public int SongsCount { get; set; }
        public int GenreCount { get; set; }
        public int RoleCount { get; set; }


        public IList<Festival> Festivals { get; set; }
        public IList<Performer> Performers { get; set; } = default!;
        public IList<Dj> Djs { get; set; }
        public IList<Song> Songs { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<Role> Roles { get; set; }
        
        public async Task OnGetAsync()
        {
            Festivals = await _context.Festivals.ToListAsync();
            Performers = await _context.Performers.ToListAsync();
            Djs = await _context.Djs.ToListAsync();
            Songs = await _context.Songs.ToListAsync();
            Genres = await _context.Genres.ToListAsync();
            Roles = await _context.Roles.ToListAsync();

            FestivalsCount = FestivalsCount;
            PerformerCount = Performers.Count;
            DjCount = Djs.Count;
            SongsCount = Songs.Count;
            GenreCount = Genres.Count;
            RoleCount = Roles.Count;
        }
    }
}
    