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
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public DjSong DjSong { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DjSong = await _context.DjSongs
                .Include(d => d.Dj)
                .Include(d => d.Song).FirstOrDefaultAsync(m => m.DjSongId == id);

            if (DjSong == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
