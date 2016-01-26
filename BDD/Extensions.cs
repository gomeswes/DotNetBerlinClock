using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BerlinClockHcl.BDD
{
    public static class Extensions
    {
        public static string RemoveCarriageReturn(this String theString)
        {
            if (!string.IsNullOrWhiteSpace(theString))
            {
                return Regex.Replace(theString, @"\r", "");
            }
            return theString;
        }

        public static string CheckAndCastToNull(this String theString)
        {
            if (theString.Equals("null", StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }
            return theString;

        }
    }
}
