using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace telprov
{
    class Utility
    {
        public static bool isPhoneNumber(string num)
        {
            return Regex.Match(num, @"^\+[0-9]{12}$").Success;
        }
    }
}
