using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.UserDtos
{
    public class UserDto
    {
        //Kullanıcı bilgilerini taşımak için kullanılır.
        public Guid UserId { get; set; } // Kullanıcı kimliği
        public string Name { get; set; } // Kullanıcı adı
        public string Email { get; set; } // Kullanıcı emaili
    }
}
