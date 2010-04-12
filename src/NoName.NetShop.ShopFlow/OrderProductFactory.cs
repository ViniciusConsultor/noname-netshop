using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace NoName.NetShop.ShopFlow
{
    class OrderProductFactory
    {
        private OrderProductFactory(){}
        private static OrderProductFactory instance = new OrderProductFactory();
        public static OrderProductFactory Instance()
        {
            return instance;
        }

        public OrderProduct CreateOrderProduct()
        {
            return null;
        }

        /// <summary>
        /// 从外部传入的参数来构造订单商品
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="productId"></param>
        /// <param name="opType"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        internal OrderProduct CreateOrderProduct(int productId,int quantity, OrderType opType, System.Collections.Specialized.NameValueCollection paras)
        {
            OrderProduct op = null;
            OrderProduct bll = GetOrderProductBll(opType);
            op = bll.CreateOrderProduct(productId,quantity, opType, paras);
            return op;
        }

        /// <summary>
        /// 从cookie中恢复商品，参数的顺序由各个商品各自定义
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="productId"></param>
        /// <param name="opType"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        internal OrderProduct CreateOrderProduct(int productId,int quantity, OrderType opType, string[] paras)
        {
            OrderProduct op = null;
            OrderProduct bll = GetOrderProductBll(opType);
            NameValueCollection nv = bll.GetParasFromCookieValue(paras);
            op = bll.CreateOrderProduct(productId,quantity, opType, nv);
            return op;
        }

        /// <summary>
        /// 从cookie的值中恢复购物商品参数信息
        /// </summary>
        /// <param name="opType"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        internal NameValueCollection GetParasFromCookieValue(OrderType opType, string[] paras)
        {
            OrderProduct bll = GetOrderProductBll(opType);
            return bll.GetParasFromCookieValue(paras);
        }


        private OrderProduct GetOrderProductBll(OrderType opType)
        {
            OrderProduct bll = null;
            switch (opType)
            {
                case OrderType.Common:
                    bll = new CommOrderProduct();
                    break;
                case OrderType.Gift:
                    bll = new GiftOrderProduct();
                    break;
                case OrderType.Suit:
                    bll = new SuitOrderProduct();
                    break;
            }
            return bll;
        }
    }
}
