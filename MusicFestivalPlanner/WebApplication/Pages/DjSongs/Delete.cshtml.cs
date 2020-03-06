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
    public class DeleteModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DjSong = await _context.DjSongs.FindAsync(id);

            if (DjSong != null)
            {
                _context.DjSongs.Remove(DjSong);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
