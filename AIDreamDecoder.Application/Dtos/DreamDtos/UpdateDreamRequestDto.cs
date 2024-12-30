using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.DreamDtos
{
    public class UpdateDreamRequestDto
    {
        //Var olan bir rüyayı güncellemek için kullanılır.
        public Guid DreamId { get; set; } // Güncellenecek rüya kimliği
        public string UpdatedDescription { get; set; } // Yeni rüya açıklaması
    }
}
