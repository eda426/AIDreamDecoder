using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Entities
{
    public class Dream
    {
        // Kullanıcının analiz için gönderdiği rüya bilgilerini temsil eder.
        public int Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; } // Rüyanın oluşturulma tarihi
        public string Description { get; set; }
        public DreamAnalysis Analysis { get; set; } // Rüyanın analizi (1'e 1 ilişki)

        public Dream()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
