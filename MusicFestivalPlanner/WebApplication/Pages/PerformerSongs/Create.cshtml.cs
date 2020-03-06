using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;
using Microsoft.VisualBasic;

namespace WebApplication.Pages.PerformerSongs
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public SelectList Options { get; set; }

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public SelectList SongSelectList { get; set; } = default!;
        public SelectList PerformerSelectList { get; set; } = default!;
        public SelectList RoleSelectList { get; set; } = default!;
        
        public IActionResult OnGet()
        {
            SongSelectList = new SelectList(_context.Songs, nameof(Song.SongId), nameof(Song.SongName));
            PerformerSelectList = new SelectList(_context.Performers, nameof(Performer.PerformerId), nameof(Performer.PerformerName));
            RoleSelectList = new SelectList(_context.Roles, nameof(Role.RoleId), nameof(Role.RoleName));
            return Page();
        }

        [BindProperty]
        public PerformerSong PerformerSong { get; set; }
        
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PerformerSongs.Add(PerformerSong);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
