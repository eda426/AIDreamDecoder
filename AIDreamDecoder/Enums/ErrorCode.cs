using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Enums
{
    public enum ErrorCode
    {
        ValidationError = 1, // Doğrulama hatası
        NotFound = 2,        // Kaynak bulunamadı
        Unauthorized = 3,    // Yetkisiz erişim
        InternalError = 4    // Sistemsel hata
    }
}
