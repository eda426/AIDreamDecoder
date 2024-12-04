using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } // Benzersiz kullanıcı kimliği
        public string Name { get; set; } // Kullanıcı adı
        public string Email { get; set; } // Kullanıcı email adresi
        public string PasswordHash { get; set; } // Şifre (hashlenmiş şekilde saklanır)
        public DateTime CreatedAt { get; set; } // Kullanıcının oluşturulma tarihi
        public List<Dream> Dreams { get; set; } // Kullanıcının rüyaları (ilişki)

        public User()
        {
            Dreams = new List<Dream>();
        }
    }
}
