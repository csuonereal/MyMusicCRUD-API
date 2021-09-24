using Microsoft.EntityFrameworkCore;
using MyMusic.DataAccess.Concrete.Context;
using MyMusic.DataAccess.Interfaces;
using MyMusic.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.Concrete.Repositories
{
    public class MusicRepository : GenericRepository<Music>, IMusicRepository
    {
        public MusicRepository(MMDbContext context) : base(context) { }
        public async Task<List<Music>> GetAllWithArtistAsync()
        {
            return await _context.Musics.Include(m => m.Artist).ToListAsync();
        }

        public async Task<Music> GetWithByArtistIdAsync(int id)
        {
            return await _context.Musics.FirstOrDefaultAsync(m => m.ArtistId == id);
        }
    }
}
