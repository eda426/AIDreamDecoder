using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Enums
{
    public enum AnalysisStatus
    {
        Pending = 0, // Analiz bekleniyor
        InProgress = 1, // Analiz devam ediyor
        Completed = 2, // Analiz tamamlandı
        Failed = 3 // Analiz başarısız
    }
}
