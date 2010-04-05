using System;
using System.Collections.Generic;

using System.Text;

namespace NoName.NetShop.CommonAliPay
{
    public class FlagInfo
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static bool operator ==(FlagInfo op1, FlagInfo op2)
        {
            if (Object.Equals(op1, null)) return Object.Equals(op2, null);
            return op1.Equals(op2);
        }
        public static bool operator !=(FlagInfo op1, FlagInfo op2)
        {
            return !(op1 == op2);
        }
        public override bool Equals(object obj)
        {
            FlagInfo op = obj as FlagInfo;
            if (obj == null) return false;
            return this.Key == op.Key;
        }

    }
}
