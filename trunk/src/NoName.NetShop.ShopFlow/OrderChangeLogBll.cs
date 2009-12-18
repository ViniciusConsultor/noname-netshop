using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.ShopFlow
{
    public class OrderChangeLogBll
    {
        private readonly OrderChangeLogDal dal = new OrderChangeLogDal();
		public OrderChangeLogBll()
		{}
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(OrderChangeLogModel model)
		{
			dal.Add(model);
		}

        public void Add(string orderId, string remark,string actInfo, string userId)
        {
            OrderChangeLogModel model = new OrderChangeLogModel();
            model.OrderId = orderId;
            model.Remark = remark;
            model.Operator = userId;
            model.ActInfo = actInfo;
            dal.Add(model);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<OrderChangeLogModel> GetOrderLogs(string orderId)
		{
            return dal.GetOrderLogs(orderId);
		}
	
		#endregion  成员方法
    }
}
