using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Specifications
{
    public class DreamsByUserSpecification : BaseSpecification<DreamAnalysis>
    {
        public DreamsByUserSpecification(Guid userId)
            : base(dream => dream.UserId == userId)
        {
        }
    }
}
