using AIDreamDecoder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Repositories
{
    public interface IDreamRepository
    {
        Task<List<Dream>> GetAllDreamsAsync(); // Tüm rüyaları getir
        Task<Dream> GetDreamByIdAsync(Guid id); // Belirli bir rüyayı getir
        Task AddDreamAsync(Dream dream); // Yeni rüya ekle
        Task<bool> DeleteDreamAsync(Guid id); // Rüya sil
    }

}
