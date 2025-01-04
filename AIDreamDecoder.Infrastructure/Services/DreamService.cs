using AIDreamDecoder.Application.Dtos.DreamDtos;
using AIDreamDecoder.Application.Interfaces;
using AIDreamDecoder.Domain.Entities;
using AIDreamDecoder.Domain.Enums;
using AIDreamDecoder.Infrastructure.Repositories; // Bu satırı ekleyin
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Services
{
    public class DreamService : IDreamService
    {
        private readonly IAIDreamInterpreterService _aiService;
        private readonly IDreamRepository _dreamRepository;
        private readonly ILogger<DreamService> _logger;

        public DreamService(IDreamRepository dreamRepository, IAIDreamInterpreterService aiService, ILogger<DreamService> logger)
        {
            _dreamRepository = dreamRepository;
            _aiService = aiService;
            _logger = logger;
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
            try
            {
                _logger.LogInformation("Starting dream interpretation for user {Id}", dreamDto.Id);

                //Get AI interpretation
                var interpretation = await _aiService.InterpretDreamAsync(dreamDto.Description);

                var dream = new Dream
                {
                    Id = dreamDto.Id,
                    Description = dreamDto.Description,
                    Analysis = new DreamAnalysis
                    {
                        AnalysisResult = interpretation,
                        Status = AnalysisStatus.Completed,
                        CreatedAt = DateTime.Now,
                    }
                };

                await _dreamRepository.AddAsync(dream);
                _logger.LogInformation("Successfully saved dream and interpretation for user {Id}", dreamDto.Id);
                
                return dream.Id; //Eğer kaydedilen rüyanın sadece Idsi bize lazımsa ID Dönüyoruz, tüm bilgilerini istersek MapToDto(dream) yazmamız lazım. Ama bunun için de yukarı da Task<DreamDto> olarak güncellenmeli.

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Eror processing dream for user {Id}", dreamDto.Id);
                throw new ApplicationException("Failed to process dream interpretation", ex);
            }
            /*var dream1 = new Dream
            {
                Id = Guid.NewGuid(),
                Description = dreamDto.Description,
            };

            await _dreamRepository.AddDreamAsync(dream);
            return dream.Id;*/
        }

        public async Task<DreamDto> AddDreamWithInterpretationAsync(DreamDto dreamDto)
        {
            // Get AI interpretation
            var interpretation = await _aiService.InterpretDreamAsync(dreamDto.Description);

            // Create dream entity
            var dream = new Dream
            {
                UserId = dreamDto.Id,
                Description = dreamDto.Description,
                Analysis = new DreamAnalysis
                {
                    AnalysisResult = interpretation,
                    Status = AnalysisStatus.Completed
                }
            };

            // Save to database
            await _dreamRepository.AddAsync(dream);

            // Return DTO
            return dreamDto; //MapToDto burada hata verdiği için böyle döndüm
        }

        public async Task<bool> DeleteDreamAsync(Guid id)
        {
            return await _dreamRepository.DeleteDreamAsync(id);
        }
    }
}