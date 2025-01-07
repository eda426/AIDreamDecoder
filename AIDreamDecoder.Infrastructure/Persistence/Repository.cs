using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIDreamDecoder.Domain.Entities;
using AIDreamDecoder.Domain.Specifications;
using AIDreamDecoder.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AIDreamDecoder.Infrastructure.Persistence
{
    public class Repository<T> where T : class
    {
        private readonly AIDreamDecoderDbContext _context;

        public Repository(AIDreamDecoderDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
