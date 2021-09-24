using MyMusic.Business.Interfaces;
using MyMusic.DataAccess.UnitOfWork;
using MyMusic.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMusic.Business.Concrete
{
    public class GenericService<Table> : IGenericService<Table> where Table : class, ITable, new()
    {
        protected readonly IUOW _uow;
        public GenericService(IUOW uow)
        {
            _uow = uow;
        }
        public async Task CreateAsync(Table newTable)
        {
            await _uow.GetRepository<Table>().AddAsync(newTable);
            await _uow.CommitAsync();
        }

        public async Task DeleteAsync(Table table)
        {
            _uow.GetRepository<Table>().Remove(table);
            await _uow.CommitAsync();
        }

        public async Task<List<Table>> GetAllAsync()
        {

            return await _uow.GetRepository<Table>().GetAllAsync();
        }

        public async Task<Table> GetByIdAsync(int id)
        {
            return await _uow.GetRepository<Table>().GetByIdAsync(id);
        }

        public async Task UpdateAsync(Table table)
        {
            _uow.GetRepository<Table>().Update(table);
            await _uow.CommitAsync();
        }
    }
}
