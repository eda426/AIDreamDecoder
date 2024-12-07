using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.DreamAnalysisDtos
{
    public class DreamAnalysisDto
    {
        //Rüya analizlerinin detaylarını göstermek için kullanılır.
        public int Id { get; set; } // Analiz kimliği
        public int DreamId { get; set; } // Analizi yapılan rüyanın kimliği
        public string AnalysisResult { get; set; } // Analiz sonucu (yorum, anlam vs.)
        public string Status { get; set; } // Analiz durumu (Tamamlandı, İşleniyor vs.)
        public DateTime CreatedAt { get; set; } // Analizin oluşturulma tarihi
    }
}
