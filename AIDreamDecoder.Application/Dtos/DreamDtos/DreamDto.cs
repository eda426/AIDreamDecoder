﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.DreamDtos
{
    public class DreamDto
    {
        // Rüya detaylarını listelemek veya göstermek için kullanılır.
        public int Id { get; set; } // Rüya kimliği
        public string Description { get; set; } // Rüyanın metin açıklaması
        public DateTime CreatedAt { get; set; } // Rüyanın oluşturulma tarihi
    }
}
