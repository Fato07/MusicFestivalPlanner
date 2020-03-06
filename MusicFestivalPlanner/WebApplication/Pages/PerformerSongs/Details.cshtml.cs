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
    public class DetailsModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DetailsModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public PerformerSong PerformerSong { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PerformerSong = await _context.PerformerSongs
                .Include(b => b.Song)
                .Include(b => b.Performer)
                .Include(b => b.Role).FirstOrDefaultAsync(m => m.PerformerSongId == id);

            if (PerformerSong == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
