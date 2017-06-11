using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Utilities
{
    public static class StringExtensions
    {
        public static bool Contains(this string thisObj, string value, StringComparer compareType)
        {
            return thisObj.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
