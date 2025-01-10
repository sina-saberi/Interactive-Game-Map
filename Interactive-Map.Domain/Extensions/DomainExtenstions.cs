using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Domain.Extensions
{
    public static class DomainExtenstions
    {
        public static bool NormalizedEquals(this string a, string b)
        {
            if (a == null || b == null)
                return false;

            return a.Trim().Equals(b.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
