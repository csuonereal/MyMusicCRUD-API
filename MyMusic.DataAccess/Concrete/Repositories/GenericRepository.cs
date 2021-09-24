using Microsoft.EntityFrameworkCore;
using MyMusic.DataAccess.Concrete.Context;
using MyMusic.DataAccess.Interfaces;
using MyMusic.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.DataAccess.Concrete.Repositories
{
    public class GenericRepository<Table> : IGenericRepository<Table> where Table : class, ITable, new()
    {
        protected MMDbContext _context;
        public GenericRepository(MMDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Table t)
        {
            await _context.Set<Table>().AddAsync(t);
        }

        public async Task AddRangeAsync(List<Table> tables)
        {
            await _context.Set<Table>().AddRangeAsync(tables);
        }

        public async Task<List<Table>> GetAllAsync()
        {
            return await _context.Set<Table>().ToListAsync();
        }

        public async Task<List<Table>> GetAllAsync(Expression<Func<Table, bool>> filter)
        {
            return await _context.Set<Table>().Where(filter).ToListAsync();
        }

        public async Task<List<Table>> GetAllAsync(Expression<Func<Table, ITable>> key)
        {
            return await _context.Set<Table>().OrderByDescending(key).ToListAsync();
        }

        public async Task<Table> GetAsync(Expression<Func<Table, bool>> filter)
        {
            return await _context.Set<Table>().FirstOrDefaultAsync(filter);
        }

        public  async Task<Table> GetByIdAsync(int id)
        {
            return await _context.Set<Table>().FindAsync(id);
        }

        public void Remove(Table t)
        {
             _context.Remove(t);
        }

        public void RemoveRange(List<Table> tables)
        {
            _context.RemoveRange(tables);
        }

        public void Update(Table t)
        {
            _context.Update(t);
        }
    }
}
