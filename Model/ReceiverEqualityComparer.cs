using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceSimulator.Model
{
    class ReceiverEqualityComparer : EqualityComparer<Receiver>
    {
        public override bool Equals(Receiver x, Receiver y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;

            return x.IP.Equals(y.IP);
        }

        public override int GetHashCode([DisallowNull] Receiver obj)
        {
            var hashcode = obj.IP.ToString();

            return hashcode.GetHashCode();
        }
    }
}
