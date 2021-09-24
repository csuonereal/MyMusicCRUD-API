using MyMusic.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusic.Business.Interfaces
{
    public interface IGenericService<Table> where Table : class, ITable, new()
    {
        Task CreateAsync(Table newTable);
        Task UpdateAsync(Table table);
        Task DeleteAsync(Table table);
        Task<List<Table>> GetAllAsync();
        Task<Table> GetByIdAsync(int id);
    }
}
