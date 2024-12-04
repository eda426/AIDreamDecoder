using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Entities
{
    public class User
    {
        public int Id { get; set; } // Kullanıcı kimliği (primary key)
        public string FirstName { get; set; } // Kullanıcının adı
        public string LastName { get; set; } // Kullanıcının soyadı
        public string Email { get; set; } // Kullanıcının e-posta adresi
        public string PasswordHash { get; set; } // Kullanıcının şifre hash'i
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Kullanıcı oluşturulma tarihi

        // Kullanıcının geçmiş analizlerini tutan ilişki
        public ICollection<Dream> Dreams { get; set; }

        // Kullanıcının tam adını döndüren yardımcı bir özellik
        public string FullName => $"{FirstName} {LastName}";
    }
}
