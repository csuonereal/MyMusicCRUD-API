using MyMusic.Business.Interfaces;
using MyMusic.DataAccess.UnitOfWork;
using MyMusic.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Business.Concrete
{
    public class MusicService : GenericService<Music>, IMusicService
    {
    
        public MusicService(IUOW uow):base(uow) { }

        public async Task<List<Music>> GetMusicsByArtistId(int id)
        {
            return await _uow.Musics.GetAllAsync(m => m.ArtistId == id);
        }
    }
}
