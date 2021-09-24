using MyMusic.DataAccess.Concrete.Context;
using MyMusic.DataAccess.Concrete.Repositories;
using MyMusic.DataAccess.Interfaces;
using MyMusic.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.UnitOfWork
{
    public class UOW : IUOW
    {
        private readonly MMDbContext _context;
        public IMusicRepository Musics { get; set; }
        public IArtistRepository Artists { get; set; }
        public UOW(MMDbContext context)
        {
            _context = context;
            Musics = new MusicRepository(_context);
            Artists = new ArtistRepository(_context);
        }

      
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }



        IGenericRepository<Table> IUOW.GetRepository<Table>()
        {
            return new GenericRepository<Table>(_context);
        }


    }
}
