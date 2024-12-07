using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.UserDtos
{
    public class UserRegistrationDto
    {
        //Kullanıcı kayıt işlemi için gerekli verileri içerir.
        public string Name { get; set; } // Kullanıcı adı
        public string Email { get; set; } // Kullanıcı emaili
        public string Password { get; set; } // Şifre
    }
}
