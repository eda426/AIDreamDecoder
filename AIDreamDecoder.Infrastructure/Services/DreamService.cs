using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AIDreamDecoder.Application.Dtos.DreamDtos;
using AIDreamDecoder.Domain.Entities;
using AIDreamDecoder.Infrastructure.Persistence;

namespace AIDreamDecoder.Infrastructure.Services
{
    public class DreamService
    {
        private readonly Repository<Dream> _dreamRepository;

        public DreamService(Repository<Dream> dreamRepository)
        {
            _dreamRepository = dreamRepository;
        }

        public async Task CreateDreamAsync(CreateDreamRequestDto requestDto)
        {
            var dream = new Dream
            {
                Description = requestDto.DreamDescription,
                UserId = requestDto.UserId
            };

            await _dreamRepository.AddAsync(dream);
        }

        public async Task<IEnumerable<DreamDto>> GetAllDreamsAsync()
        {
            var dreams = await _dreamRepository.GetAllAsync();
            return dreams.Select(d => new DreamDto
            {
                Id = d.Id,
                Description = d.Description,
                CreatedAt = d.CreatedAt
            });
        }
    }
}
