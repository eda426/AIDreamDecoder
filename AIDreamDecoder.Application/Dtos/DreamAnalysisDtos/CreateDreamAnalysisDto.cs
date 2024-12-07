using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.DreamAnalysisDtos
{
    public class CreateDreamAnalysisDto
    {
        // Yeni bir rüya analizi başlatmak için gerekli bilgileri içerir.
        public int DreamId { get; set; } // Analizi yapılacak rüya kimliği
        public string AIModelUsed { get; set; } // Kullanılan yapay zeka modeli (ör. "GPT-4")
    }
}
