using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Application.Dtos.UserDtos
{
    public class UserLoginDto
    {
        // Kullanıcının giriş yapması için gerekli bilgileri içerir
        public string Email { get; set; } // Kullanıcı emaili
        public string Password { get; set; } // Şifre
    }
}
