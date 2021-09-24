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
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(MMDbContext context):base(context) {}
        public async Task<List<Artist>> GetAllWithMusicsAsync()
        {
            return await _context.Artists.Include(m => m.Musics).ToListAsync();
        }

        public async Task<Artist> GetWithMusicsById(int id)
        {
            return await _context.Artists.Include(m => m.Musics).FirstOrDefaultAsync(m=>m.Id==id);
        }
    }
}
