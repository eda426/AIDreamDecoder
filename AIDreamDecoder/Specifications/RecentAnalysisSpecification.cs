using AIDreamDecoder.Entities;
using AIDreamDecoder.Enums;
using AIDreamDecoder.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Entities
{
    public class RecentAnalysisSpecification : BaseSpecification<DreamAnalysiss>  // Buradaki sınıf ismini doğru yazdığınızdan emin olun
    {
        public RecentAnalysisSpecification(int maxResults = 10)
            : base(dream => dream.CreatedAt >= DateTime.UtcNow.AddDays(-7)) // Son 7 gün içindeki analizler
        {
            AddOrderByDescending(dream => dream.CreatedAt);  // En yeni analizler önce gelir
            AddTake(maxResults);  // Maksimum sayıda sonuç
        }
    }
}
