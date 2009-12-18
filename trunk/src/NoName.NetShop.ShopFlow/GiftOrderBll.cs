using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    public class GiftOrderBll
    {
        private readonly GiftOrderDal dal = new GiftOrderDal();
        private readonly GiftOrderItemDal itemdal = new GiftOrderItemDal();
        private readonly OrderChangeLogDal logdal = new OrderChangeLogDal();
        
		#region  成员方法
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public GiftOrderModel GetModel(string OrderId)
		{
			return dal.GetModel(OrderId);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GiftOrderModel GetModel(string OrderId,string userId)
        {
            return dal.GetModel(OrderId,userId);
        }
        public List<GiftOrderItemModel> GetOrderItems(string orderId)
        {
            return itemdal.GetOrderItems(orderId);
        }

        public List<OrderChangeLogModel> GetChangeLogs(string orderId)
        {
            return logdal.GetOrderLogs(orderId);
        }

        public bool ChangeOrderStatus(string orderId, OrderStatus ostatus)
        {
            return dal.ChangeOrderStatus(orderId, ostatus);

        }


		#endregion  成员方法
    }
}
