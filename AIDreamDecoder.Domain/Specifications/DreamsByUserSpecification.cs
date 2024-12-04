using AIDreamDecoder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Domain.Specifications
{
    public class DreamsByUserSpecification : BaseSpecification<Dream>
    {
        public DreamsByUserSpecification(Guid userId)
            : base(dream => dream.UserId == userId)
        {
            AddOrderByDescending(dream => dream.CreatedAt); // En yeni rüyalar önce gelir
        }
    }
}
