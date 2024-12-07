using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.DreamDtos
{
    public class CreateDreamRequestDto
    {
        //Kullanıcının yeni bir rüya kaydı göndermesi için gerekli olan bilgileri içerir.
        public string DreamDescription { get; set; } // Rüyanın açıklaması
        public Guid UserId { get; set; } // Kullanıcının benzersiz kimliği
    }
}
