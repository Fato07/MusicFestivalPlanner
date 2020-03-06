using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApplication.Pages.DjSongs
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public SelectList DJSelectList { get; set; } = default!;
        public SelectList SongSelectList { get; set; } = default!;
        
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
            
            DJSelectList = new SelectList(_context.Djs, nameof(Dj.DjId), nameof(Dj.StageName));
            SongSelectList = new SelectList(_context.Songs, nameof(Song.SongId), nameof(Song.SongName));
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DjSong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DjSongExists(DjSong.DjSongId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DjSongExists(int id)
        {
            return _context.DjSongs.Any(e => e.DjSongId == id);
        }
    }
}
