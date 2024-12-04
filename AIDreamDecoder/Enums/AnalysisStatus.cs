using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Enums
{
    public enum AnalysisStatus
    {
        Pending = 1,    // Analiz bekleniyor
        Completed = 2,  // Analiz tamamlandı
        Failed = 3      // Analiz başarısız
    }
}
