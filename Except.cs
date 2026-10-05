using System;
using System.Collections.Generic;
using System.Text;

namespace App7_507
{
    static internal class Except
    {
        public static string GetValueOrEmpty(this IDictionary<string, string?> dict, string key, string defaultValue = "")
        {
            if (dict.TryGetValue(key, out var value) && value != null)
            {
                return value;
            }
            return defaultValue;
        }
    }
}
