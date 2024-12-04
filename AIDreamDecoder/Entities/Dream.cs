using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Entities
{
    public class Dream
    {
        // Kullanıcının analiz için gönderdiği rüya bilgilerini temsil eder.
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}
