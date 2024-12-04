using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Domain.Entities
{
    public class Dream
    {
        public int Id { get; set; } // Benzersiz rüya kimliği
        public Guid UserId { get; set; } // Rüyanın sahibi olan kullanıcının ID'si
        public string Description { get; set; } // Rüyanın metni
        public DateTime CreatedAt { get; set; } // Rüyanın oluşturulma tarihi
        public DreamAnalysis Analysis { get; set; } // Rüyanın analizi (1'e 1 ilişki)

        public Dream()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
