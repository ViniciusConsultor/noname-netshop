using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    public enum PayStatus
    {
        WaitForPay=0,
        PaySucc=1,
        Refunding=2,
        Refunded=3
    }
}
