using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Pages
{
    public class OverViewModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public OverViewModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public int PerformerCount { get; set; }
        public int DjCount { get; set; }
        
        public int SongsCount { get; set; }
        public IList<Performer> Performers { get; set; } = default!;
        public IList<Dj> Djs { get; set; }
        public IList<Song> Songs { get; set; }
        

        public async Task OnGetAsync()
        {
            Performers = await _context.Performers.ToListAsync();
            PerformerCount = Performers.Count;
            
            Djs = await _context.Djs.ToListAsync(); 
            DjCount = Djs.Count;
            
            Songs = await _context.Songs.ToListAsync();
            SongsCount = Songs.Count;
        }
        
    }
}