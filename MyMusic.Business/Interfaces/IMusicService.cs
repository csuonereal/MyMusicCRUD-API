using MyMusic.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Business.Interfaces
{
    public interface IMusicService:IGenericService<Music>
    {
        Task<List<Music>> GetMusicsByArtistId(int id);


    }
}
