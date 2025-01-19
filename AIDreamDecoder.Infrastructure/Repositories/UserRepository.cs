using AIDreamDecoder.Domain.Entities;
using AIDreamDecoder.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AIDreamDecoderDbContext _dbContext;

        public UserRepository(AIDreamDecoderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _dbContext.Users
                .Include(u => u.Dreams) // Kullanıcının rüyalarını da çekmek için
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _dbContext.Users
                .Include(u => u.Dreams)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> CreateAsync(User user)
        {
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await FindByIdAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
