using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.ValueObjects
{

    //Rüya metni için özel bir doğrulama nesnesi.
    public class DreamDescription
    {
        public string Value { get; private set; }

        public DreamDescription(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Dream description cannot be empty.");

            if (value.Length < 10)
                throw new ArgumentException("Dream description must be at least 10 characters long.");

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DreamDescription other)
                return Value == other.Value;

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
