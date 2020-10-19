using System;
using System.Collections.Generic;
using System.Text;

namespace Bist_1.ExtensionMethods
{
    public static class NumberExtensions
    {
        public static bool IsDoubleEqual(this double val1, double val2)
        {
            return Math.Abs(val1 - val2) < 1e-5;
        }

        public static bool IsNullOrEmpty(this string inStr)
        {
            return string.IsNullOrEmpty(inStr);
        }

    }
}
