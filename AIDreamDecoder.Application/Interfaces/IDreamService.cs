using AIDreamDecoder.Application.Dtos.DreamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Interfaces
{
    public interface IDreamService
    {
        Task<List<DreamDto>> GetDreamsAsync(); // Tüm rüyaları getir
        Task<DreamDto> GetDreamByIdAsync(Guid id); // Belirli bir rüyayı getir
        Task<Guid> AddDreamAsync(DreamDto dreamDto); // Yeni rüya ekle
        Task<bool> DeleteDreamAsync(Guid id); // Rüya sil
        Task<DreamDto> AddDreamWithInterpretationAsync(DreamDto dreamDto); //AI için
        Task<Guid> AddDreamWithUserTransactionAsync(Guid userId, DreamDto dreamDto);
    }

}
