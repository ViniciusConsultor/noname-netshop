using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    public enum OrderStatus
    {
        已创建=0,
        备货中=1,
        已发货=2,
        物流到货=3,
        买家确认=4,
        买家退货=5,
        交易完成=6,
        交易失败=8, // 退款完成，交易失败；买家未签收，交易失败
        交易关闭=9
    }
}
