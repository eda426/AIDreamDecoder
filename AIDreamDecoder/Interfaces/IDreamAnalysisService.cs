using AIDreamDecoder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Interfaces
{
    public interface IDreamAnalysisService
    {
        Task<AnalysisResult> AnalyzeDreamAsync(Dream dream);
    }
}
