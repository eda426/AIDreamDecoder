using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.Exceptions
{
    public class InvalidDreamException : Exception
    {
        public InvalidDreamException(string message)
            : base(message)
        {
        }

        public InvalidDreamException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ToString()
        {
            return $"Invalid Dream Error: {Message}";
        }
    }
}
