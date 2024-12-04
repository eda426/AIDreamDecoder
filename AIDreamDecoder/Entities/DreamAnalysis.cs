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
        public int Id { get; set; }
        public Guid UserId { get; set; }  // Kullanıcı ID'si
        public string DreamDescription { get; set; }  // Rüya açıklaması
        public DateTime CreatedAt { get; set; }  // Analiz tarihi
        public AnalysisStatus Status { get; set; }  // Analiz durumu (Enum)
    }
}
