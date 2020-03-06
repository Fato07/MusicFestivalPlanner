using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<Dj> Djs { get; set; }

        public DbSet<DjSong> DjSongs { get; set; }

        public DbSet<Festival> Festivals { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Performer> Performers { get; set; }
        
        public DbSet<PerformerSong> PerformerSongs { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Song> Songs { get; set; }
        
        public AppDbContext(DbContextOptions option): base(option)
        {
        }
    }
}