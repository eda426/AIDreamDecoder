using AIDreamDecoder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(Guid id); // ID ile kullanıcıyı bul
        Task<User> FindByEmailAsync(string email); // Email ile kullanıcıyı bul
        Task<User> CreateAsync(User user); // Yeni kullanıcı oluştur
        Task UpdateAsync(User user); // Kullanıcıyı güncelle
        Task DeleteAsync(Guid id); // Kullanıcıyı sil
    }
}
