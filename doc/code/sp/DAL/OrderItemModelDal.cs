using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using Maticsoft.DBUtility;//请先添加引用
namespace NoName.NetShop.DAL
{
	/// <summary>
	/// 数据访问类OrderItemModelDal。
	/// </summary>
	public class OrderItemModelDal
	{
		public OrderItemModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(OrderItem)+1 from spOrderItem";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OrderItem)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrderItem_Exists");
			db.AddInParameter(dbCommand, "OrderItem", DbType.Int32,OrderItem);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			int.TryParse(obj.ToString(),out result);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.OrderItemModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrderItem_ADD");
			db.AddInParameter(dbCommand, "OrderId", DbType.Int32, model.OrderId);
			db.AddInParameter(dbCommand, "OrderItem", DbType.Int32, model.OrderItem);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "ProductFee", DbType.Decimal, model.ProductFee);
			db.AddInParameter(dbCommand, "Quantity", DbType.Int32, model.Quantity);
			db.AddInParameter(dbCommand, "DerateFee", DbType.Decimal, model.DerateFee);
			db.AddInParameter(dbCommand, "MerchantPrice", DbType.Decimal, model.MerchantPrice);
			db.AddInParameter(dbCommand, "TotalFee", DbType.Decimal, model.TotalFee);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.OrderItemModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrderItem_Update");
			db.AddInParameter(dbCommand, "OrderId", DbType.Int32, model.OrderId);
			db.AddInParameter(dbCommand, "OrderItem", DbType.Int32, model.OrderItem);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "ProductFee", DbType.Decimal, model.ProductFee);
			db.AddInParameter(dbCommand, "Quantity", DbType.Int32, model.Quantity);
			db.AddInParameter(dbCommand, "DerateFee", DbType.Decimal, model.DerateFee);
			db.AddInParameter(dbCommand, "MerchantPrice", DbType.Decimal, model.MerchantPrice);
			db.AddInParameter(dbCommand, "TotalFee", DbType.Decimal, model.TotalFee);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int OrderItem)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrderItem_Delete");
			db.AddInParameter(dbCommand, "OrderItem", DbType.Int32,OrderItem);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.OrderItemModel GetModel(int OrderItem)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrderItem_GetModel");
			db.AddInParameter(dbCommand, "OrderItem", DbType.Int32,OrderItem);

			NoName.NetShop.Model.OrderItemModel model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OrderId,OrderItem,ProductId,ProductFee,Quantity,DerateFee,MerchantPrice,TotalFee ");
			strSql.Append(" FROM spOrderItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "spOrderItem");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NoName.NetShop.Model.OrderItemModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OrderId,OrderItem,ProductId,ProductFee,Quantity,DerateFee,MerchantPrice,TotalFee ");
			strSql.Append(" FROM spOrderItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.OrderItemModel> list = new List<NoName.NetShop.Model.OrderItemModel>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
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
		public NoName.NetShop.Model.OrderItemModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.OrderItemModel model=new NoName.NetShop.Model.OrderItemModel();
			object ojb; 
			ojb = dataReader["OrderId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderId=(int)ojb;
			}
			ojb = dataReader["OrderItem"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderItem=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["ProductFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductFee=(decimal)ojb;
			}
			ojb = dataReader["Quantity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Quantity=(int)ojb;
			}
			ojb = dataReader["DerateFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DerateFee=(decimal)ojb;
			}
			ojb = dataReader["MerchantPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MerchantPrice=(decimal)ojb;
			}
			ojb = dataReader["TotalFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TotalFee=(decimal)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

