using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Exceptions
{
    public class OpenAiApiException : Exception
    {
        public int StatusCode { get; }

        public OpenAiApiException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public OpenAiApiException(string message, int statusCode, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public override string ToString()
        {
            return $"OpenAI API Error: {Message} (Status Code: {StatusCode})";
        }
    }
}
