using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Entities
{
    public class AnalysisResult
    {
        //OpenAI tarafından sağlanan analiz sonuçlarını tutar.
        public int Id { get; set; }
        public int DreamId { get; set; }
        public string Analysis { get; set; }
        public DateTime AnalysisDate { get; set; }
    }

}
