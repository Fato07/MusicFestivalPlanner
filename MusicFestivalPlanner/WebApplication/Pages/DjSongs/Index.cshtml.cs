using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApplication.Pages.DjSongs
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<DjSong> DjSong { get;set; }

        public async Task OnGetAsync()
        {
            DjSong = await _context.DjSongs
                .Include(d => d.Dj)
                .Include(d => d.Song).ToListAsync();
        }
    }
}
