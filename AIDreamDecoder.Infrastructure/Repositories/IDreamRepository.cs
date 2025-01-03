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
        Task<List<Dream>> GetAllDreamsAsync();
        Task<Dream> GetDreamByIdAsync(Guid id);
        Task AddDreamAsync(Dream dream);
        Task<bool> DeleteDreamAsync(Guid id);
        Task<Dream> AddAsync(Dream dream);
    }
}
