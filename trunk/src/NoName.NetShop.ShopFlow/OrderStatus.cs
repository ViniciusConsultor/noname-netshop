using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    public enum OrderStatus
    {
        Created=0,
        Confirm=1,
        Send=2,
        Finish=3,
        Closed=9
    }
}
