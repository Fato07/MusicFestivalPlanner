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

namespace WebApplication.Pages.PerformerSongs
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PerformerSong PerformerSong { get; set; }
        
        public SelectList SongSelectList { get; set; } = default!;
        public SelectList PerformerSelectList { get; set; } = default!;
        public SelectList RoleSelectList { get; set; } = default!;

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
            
            SongSelectList = new SelectList(_context.Songs, nameof(Song.SongId), nameof(Song.SongName));
            PerformerSelectList = new SelectList(_context.Performers, nameof(Performer.PerformerId), nameof(Performer.PerformerName));
            RoleSelectList = new SelectList(_context.Roles, nameof(Role.RoleId), nameof(Role.RoleName));
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

            _context.Attach(PerformerSong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformerSongExists(PerformerSong.PerformerSongId))
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

        private bool PerformerSongExists(int id)
        {
            return _context.PerformerSongs.Any(e => e.PerformerSongId == id);
        }
    }
}
