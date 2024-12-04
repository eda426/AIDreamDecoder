using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Domain.ValueObjects
{
    public class AnalysisResult
    {
        public string Summary { get; set; } // Rüyanın özeti
        public string EmotionalTone { get; set; } // Rüyanın duygusal tonu
        public List<string> KeySymbols { get; set; } // Rüya içindeki önemli semboller

        public AnalysisResult()
        {
            KeySymbols = new List<string>();
        }
    }
}
