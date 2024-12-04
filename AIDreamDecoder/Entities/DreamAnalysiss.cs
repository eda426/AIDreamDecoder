using AIDreamDecoder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Entities
{
    public class DreamAnalysis
    {
        public int Id { get; set; } // Benzersiz analiz kimliği
        public int DreamId { get; set; } // Analizi yapılan rüyanın ID'si
        public string AnalysisResult { get; set; } // Analiz sonucu (örneğin, anlamlar veya yorumlar)
        public AnalysisStatus Status { get; set; } // Analizin durumu
        public DateTime CreatedAt { get; set; } // Analizin oluşturulma tarihi

        public DreamAnalysis()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
