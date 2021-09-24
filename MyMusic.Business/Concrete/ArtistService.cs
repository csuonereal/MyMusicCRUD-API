using MyMusic.Business.Interfaces;
using MyMusic.DataAccess.UnitOfWork;
using MyMusic.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusic.Business.Concrete
{
    public class ArtistService : GenericService<Artist>, IArtistService
    {
     
        public ArtistService(IUOW uow) : base(uow){}

        public async Task<List<Artist>> GetArtistsWithMusicsAsync()
        {
           return await _uow.Artists.GetAllWithMusicsAsync();
        }
    }
}
