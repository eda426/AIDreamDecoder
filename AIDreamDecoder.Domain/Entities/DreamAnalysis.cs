using AIDreamDecoder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Domain.Entities
{
    public class DreamAnalysis
    {
        public Guid Id { get; set; } // Benzersiz analiz kimliği
        public Guid DreamId { get; set; } // Analizi yapılan rüyanın ID'si
        public string AnalysisResult { get; set; } // Analiz sonucu (örneğin, anlamlar veya yorumlar)
        public AnalysisStatus Status { get; set; } // Analizin durumu
        public DateTime CreatedAt { get; set; } // Analizin oluşturulma tarihi

        // Navigation Property
        public Dream Dream { get; set; } // Analizi yapılan rüya

        public DreamAnalysis()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
