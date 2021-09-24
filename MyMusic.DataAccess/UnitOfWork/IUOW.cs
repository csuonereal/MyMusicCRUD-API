using MyMusic.DataAccess.Interfaces;
using MyMusic.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.UnitOfWork
{
    public interface IUOW
    {
        IMusicRepository Musics{get;set;}
        IArtistRepository Artists { get; set; }
        Task CommitAsync();

        IGenericRepository<Table> GetRepository<Table>() where Table : class, ITable, new();
    }
}
