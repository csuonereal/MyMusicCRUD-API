using MyMusic.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.Interfaces
{
    public interface IArtistRepository:IGenericRepository<Artist>
    {
        Task<List<Artist>> GetAllWithMusicsAsync();
        Task<Artist> GetWithMusicsById(int id);
    }
}
