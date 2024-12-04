using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDreamDecoder.ValueObjects
{
    public class AnalysisScore
    {
        public double Value { get; private set; }

        public AnalysisScore(double value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException("Analysis score must be between 0 and 1.");

            Value = value;
        }

        public override string ToString()
        {
            return $"{Value:P}"; // Yüzde formatında döndürür.
        }

        public override bool Equals(object? obj)
        {
            if (obj is AnalysisScore other)
                return Value.Equals(other.Value);

            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
