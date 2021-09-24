using MyMusic.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.Interfaces
{
    public interface IMusicRepository:IGenericRepository<Music>
    {
        Task<List<Music>> GetAllWithArtistAsync();
        Task<Music> GetWithByArtistIdAsync(int id);
    }
}
