using MyMusic.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.Interfaces
{
    public interface IGenericRepository<Table> where Table : class, ITable, new()
    {
        Task<Table> GetByIdAsync(int id);
        Task<Table> GetAsync(Expression<Func<Table, bool>> filter);
        Task<List<Table>> GetAllAsync();
        Task<List<Table>> GetAllAsync(Expression<Func<Table, bool>> filter);
        Task<List<Table>> GetAllAsync(Expression<Func<Table, ITable>> key);
        Task AddAsync(Table t);
        Task AddRangeAsync(List<Table> tables);
        void Update(Table t);
        void Remove(Table t);
        void RemoveRange(List<Table> tables);
          
    }
}
