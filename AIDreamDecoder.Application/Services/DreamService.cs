using AIDreamDecoder.Application.Dtos;
using AIDreamDecoder.Application.Dtos.DreamDtos;
using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Domain.Entities;


namespace AIDreamDecoder.Application.Services
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
            var dreams = await _dreamRepository.GetDreamsAsync();
            return dreams.Select(d => new DreamDto
            {
                Id = d.Id,
                Content = d.Content,
                Analysis = d.Analysis
            }).ToList();
        }
    }
}
