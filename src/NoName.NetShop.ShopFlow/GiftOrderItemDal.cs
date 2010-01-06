using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace NoName.NetShop.ShopFlow
{
    class GiftOrderItemDal
    {
        public GiftOrderItemDal()
		{}
		#region  成员方法

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        public List<GiftOrderItemModel> GetOrderItems(string orderId)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.OrderId,a.ProductId,a.Quantity,a.Score,a.TotalScore,b.productname ");
            strSql.Append(" FROM spGiftOrderitem as a join pdGift as b on a.productid=b.productid where orderId=@orderId");


            List<GiftOrderItemModel> list = new List<GiftOrderItemModel>();
            Database db = NoName.NetShop.Common.DBFactory.DbReader;
            DbCommand comm = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(comm, "orderId", DbType.String, orderId);

			using (IDataReader dataReader = db.ExecuteReader(comm))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
        private GiftOrderItemModel ReaderBind(IDataReader dataReader)
		{
            GiftOrderItemModel model = new GiftOrderItemModel();
			object ojb; 
			model.OrderId=dataReader["OrderId"].ToString();
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["Quantity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Quantity=(int)ojb;
			}
			ojb = dataReader["Score"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Score=(int)ojb;
			}
			ojb = dataReader["TotalScore"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TotalScore=(int)ojb;
			}
            model.ProductName = dataReader["productName"].ToString();
			return model;
		}

		#endregion  成员方法

    }
}
