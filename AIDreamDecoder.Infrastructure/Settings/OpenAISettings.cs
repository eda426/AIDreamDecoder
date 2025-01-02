using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Infrastructure.Settings
{
    public class OpenAISettings
    {
        public string ApiKey { get; set; }
        public string Model { get; set; } = "gpt-4"; // or gpt-3.5-turbo
        public float Temperature { get; set; } = 0.7f;
        public int MaxTokens { get; set; } = 2000;
    }
}
