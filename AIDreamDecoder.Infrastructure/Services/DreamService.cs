using AIDreamDecoder.Application.Dtos.DreamDtos;
using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Domain.Entities;
using AIDreamDecoder.Infrastructure.Repositories; // Bu satırı ekleyin
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Services
{
    public class DreamService : IDreamService
    {
        private readonly IDreamRepository _dreamRepository;

        public DreamService(IDreamRepository dreamRepository)
        {
            _dreamRepository = dreamRepository;
        }

        public async Task<List<DreamDto>> GetDreamsAsync()
        {
            var dreams = await _dreamRepository.GetAllDreamsAsync();
            return dreams.Select(dream => new DreamDto
            {
                Id = dream.Id,
                Description = dream.Description,
            }).ToList();
        }

        public async Task<DreamDto> GetDreamByIdAsync(Guid id)
        {
            var dream = await _dreamRepository.GetDreamByIdAsync(id);
            if (dream == null) return null;

            return new DreamDto
            {
                Id = dream.Id,
                Description = dream.Description,
            };
        }

        public async Task<Guid> AddDreamAsync(DreamDto dreamDto)
        {
            var dream = new Dream
            {
                Id = Guid.NewGuid(),
                Description = dreamDto.Description,
            };

            await _dreamRepository.AddDreamAsync(dream);
            return dream.Id;
        }

        public async Task<bool> DeleteDreamAsync(Guid id)
        {
            return await _dreamRepository.DeleteDreamAsync(id);
        }
    }
}
