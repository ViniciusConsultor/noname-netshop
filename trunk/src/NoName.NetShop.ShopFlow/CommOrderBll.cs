using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    public class CommOrderBll
    {
        private readonly CommOrderDal dal=new CommOrderDal();
        private readonly CommOrderItemDal itemdal=new CommOrderItemDal();
        private readonly OrderChangeLogDal logdal = new OrderChangeLogDal();

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CommOrderModel GetModel(string OrderId)
		{
			return dal.GetModel(OrderId);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommOrderModel GetModel(string OrderId,string userId)
        {
            return dal.GetModel(OrderId,userId);
        }
        public List<CommOrderItemModel> GetOrderItems(string orderId)
        {
            return itemdal.GetOrderItems(orderId);
        }

        public List<OrderChangeLogModel> GetChangeLogs(string orderId)
        {
            return logdal.GetOrderLogs(orderId);
        }

        public bool ChangeOrderStatus(string orderId,OrderStatus ostatus)
        {
            return dal.ChangeOrderStatus(orderId,ostatus);
                 
        }

        public bool ChangePayStatus(string orderId,PayStatus pstatus)
        {
            return dal.ChangePayStatus(orderId,pstatus);
        }

    }
}
