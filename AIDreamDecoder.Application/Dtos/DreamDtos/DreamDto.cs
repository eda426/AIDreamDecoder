using AIDreamDecoder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.DreamDtos
{
    public class DreamDto
    { // Rüya detaylarını listelemek veya göstermek için kullanılır.
        [Required]
        public Guid Id { get; set; } // Rüya kimliği
        public string Description { get; set; } // Rüyanın metin açıklaması
        public DateTime CreatedAt { get; set; } // Rüyanın oluşturulma tarihi
        public Guid UserId { get; set; } // Rüyayı oluşturan kullanıcının kimliği

        public static DreamDto MapToDto(Dream dream)
        {
            return new DreamDto
            {
                Id = dream.Id,
                Description = dream.Description,
                CreatedAt = dream.CreatedAt,
                UserId = dream.UserId // Kullanıcı kimliği ekleniyor
            };
        }
    }

    
}
