using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using WebApplication.DTO;

namespace WebApplication.Pages.Songs
{
    public class IndexModel : PageModel
    {
        public string? Search { get; set; }
        
        private readonly DAL.AppDbContext _context;

        public IndexModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<SongIndexDto> Songs { get; set; } = default!;
        public IList<Song> Song { get; set; } = default!;

        public IQueryable<SongIndexDto> GetSongs(string? search, string? toDoActionReset, int? genreId)
        {
            return _context.Songs
                .Include(b => b.Genre)
                .Include(b => b.PerformerSongs)
                .Where(b => genreId != null && b.GenreId == genreId || genreId == null)
                .Select(a => new SongIndexDto()
                {
                    Song = a,
                })
                .AsQueryable();
        }

        public async Task OnGetAsync(string? search, string? toDoActionReset, int? genreId)
        {
            if (toDoActionReset == "Reset")
            {
                Search = "";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search))
                {
                    Search = search.ToLower().Trim();
                }
            }

            var songQuery = GetSongs(search, toDoActionReset, genreId);

            if (!string.IsNullOrWhiteSpace(Search))
            {
                songQuery = SearchInSongs(songQuery, search!);
            }

            songQuery = songQuery.OrderBy(b => b.Song.SongName);
            
            Songs = await songQuery.ToListAsync();
        }

        private void FixDto(IList<SongIndexDto> songs)
        {
        }

        private IQueryable<SongIndexDto> SearchInSongs(IQueryable<SongIndexDto> songs, string search)
        {
            return songs.Where(b =>
                b.Song.SongName.ToLower().Contains(Search!) ||
                b.Song.Genre.GenreName.ToLower().Contains(Search!)
            );
        }
    }
}
