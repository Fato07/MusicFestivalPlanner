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
    public class DeleteModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public DeleteModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PerformerSong PerformerSong { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PerformerSong = await _context.PerformerSongs.FirstOrDefaultAsync(m => m.PerformerSongId == id);

            if (PerformerSong == null)
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

            PerformerSong = await _context.PerformerSongs.FindAsync(id);

            if (PerformerSong != null)
            {
                _context.PerformerSongs.Remove(PerformerSong);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
