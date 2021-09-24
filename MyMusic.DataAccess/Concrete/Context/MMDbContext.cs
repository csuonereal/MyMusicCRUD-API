using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyMusic.DataAccess.Configs;
using MyMusic.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.Concrete.Context
{
    public class MMDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1URAFQP;database=MyMusicAPI;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicConfig());
            modelBuilder.ApplyConfiguration(new ArtistConfig());
        }
    }
}
