using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;
using Microsoft.Extensions.Primitives;

namespace WebApplication.Pages.Songs
{
    
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        
        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public SelectList GenreSelectList { get; set; } = default!;
        
       

        public IActionResult OnGet()
        {
            GenreSelectList = new SelectList(_context.Genres, nameof(Genre.GenreId), nameof(Genre.GenreName));
            return Page();
        }
        
        [BindProperty]
        public Song Song { get; set; }
        
        [BindProperty] public Genre Genre { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Songs.Add(Song);
            _context.Genres.Add(Genre);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
