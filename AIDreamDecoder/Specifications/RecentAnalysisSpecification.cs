using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Specifications
{
    public class RecentAnalysisSpecification : BaseSpecification<DreamAnalysis>
    {
        public RecentAnalysisSpecification(int maxResults = 10)
            : base(dream => dream.CreatedAt >= DateTime.UtcNow.AddDays(-7)) // Son 7 gün içindeki analizler
        {
            AddOrderByDescending(dream => dream.CreatedAt);  // En yeni analizler önce gelir
            AddTake(maxResults);  // Maksimum sayıda sonuç
        }
    }
}
