using AIDreamDecoder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Domain.Entities
{
    public class Dream
    {
        public Guid Id { get; set; } // Benzersiz rüya kimliği
        public Guid UserId { get; set; } // Rüyanın sahibi olan kullanıcının ID'si
        public string Description { get; set; } // Rüyanın metni
        public InterpretationType InterpretationType { get; set; } //Rüyanın kime göre yorumlanacağı
        public DateTime CreatedAt { get; set; } // Rüyanın oluşturulma tarihi
        public DreamAnalysis Analysis { get; set; } // Rüyanın analizi (1'e 1 ilişki)

        // Navigation Property
        public User User { get; set; } // Rüyanın sahibi olan kullanıcı

        public Dream()
        {
            CreatedAt = DateTime.UtcNow;
        }

    }
}
