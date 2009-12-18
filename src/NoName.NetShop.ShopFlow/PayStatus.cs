using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    public enum PayStatus
    {
        等待付款=0,
        支付成功=1,
        退款申请中=2,
        退款完成=3
    }
}
