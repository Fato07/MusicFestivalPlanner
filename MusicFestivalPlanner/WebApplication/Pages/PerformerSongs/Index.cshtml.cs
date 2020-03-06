using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApplication.Pages.PerformerSongs
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<PerformerSong> PerformerSong { get;set; }

        public async Task OnGetAsync()
        {
            PerformerSong = await _context.PerformerSongs
                .Include(b => b.Song)
                .Include(b => b.Performer)
                .Include(b => b.Role)
                .ToListAsync();
        }
    }
}
