using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApplication.Pages.DjSongs
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }
        
        public SelectList DJSelectList { get; set; } = default!;
        public SelectList SongSelectList { get; set; } = default!;
        
        public IActionResult OnGet()
        {
            DJSelectList = new SelectList(_context.Djs, nameof(Dj.DjId), nameof(Dj.StageName));
            SongSelectList = new SelectList(_context.Songs, nameof(Song.SongId), nameof(Song.SongName));
            return Page();
        }
        
        
        [BindProperty]
        public DjSong DjSong { get; set; }
        
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DjSongs.Add(DjSong);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
