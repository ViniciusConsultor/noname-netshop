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
	/// 数据访问类OrderModelDal。
	/// </summary>
	public class OrderModelDal
	{
		public OrderModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(OrderId)+1 from spOrder";
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
		public bool Exists(int OrderId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrder_Exists");
			db.AddInParameter(dbCommand, "OrderId", DbType.Int32,OrderId);
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
		public void Add(NoName.NetShop.Model.OrderModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrder_ADD");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "OrderId", DbType.Int32, model.OrderId);
			db.AddInParameter(dbCommand, "OrderStatus", DbType.Byte, model.OrderStatus);
			db.AddInParameter(dbCommand, "PayMethod", DbType.Byte, model.PayMethod);
			db.AddInParameter(dbCommand, "ShipMethod", DbType.Byte, model.ShipMethod);
			db.AddInParameter(dbCommand, "PayStatus", DbType.Byte, model.PayStatus);
			db.AddInParameter(dbCommand, "Paysum", DbType.Decimal, model.Paysum);
			db.AddInParameter(dbCommand, "ShipFee", DbType.Decimal, model.ShipFee);
			db.AddInParameter(dbCommand, "ProductFee", DbType.Decimal, model.ProductFee);
			db.AddInParameter(dbCommand, "DerateFee", DbType.Decimal, model.DerateFee);
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32, model.AddressId);
			db.AddInParameter(dbCommand, "RecieverName", DbType.AnsiString, model.RecieverName);
			db.AddInParameter(dbCommand, "RecieverEmail", DbType.AnsiString, model.RecieverEmail);
			db.AddInParameter(dbCommand, "RecieverPhone", DbType.AnsiString, model.RecieverPhone);
			db.AddInParameter(dbCommand, "Postalcode", DbType.AnsiString, model.Postalcode);
			db.AddInParameter(dbCommand, "RecieverCity", DbType.AnsiString, model.RecieverCity);
			db.AddInParameter(dbCommand, "RecieverProvince", DbType.AnsiString, model.RecieverProvince);
			db.AddInParameter(dbCommand, "AddressDetial", DbType.AnsiString, model.AddressDetial);
			db.AddInParameter(dbCommand, "ChangeTime", DbType.DateTime, model.ChangeTime);
			db.AddInParameter(dbCommand, "PayTime", DbType.DateTime, model.PayTime);
			db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
			db.AddInParameter(dbCommand, "OrderType", DbType.Byte, model.OrderType);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.OrderModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrder_Update");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "OrderId", DbType.Int32, model.OrderId);
			db.AddInParameter(dbCommand, "OrderStatus", DbType.Byte, model.OrderStatus);
			db.AddInParameter(dbCommand, "PayMethod", DbType.Byte, model.PayMethod);
			db.AddInParameter(dbCommand, "ShipMethod", DbType.Byte, model.ShipMethod);
			db.AddInParameter(dbCommand, "PayStatus", DbType.Byte, model.PayStatus);
			db.AddInParameter(dbCommand, "Paysum", DbType.Decimal, model.Paysum);
			db.AddInParameter(dbCommand, "ShipFee", DbType.Decimal, model.ShipFee);
			db.AddInParameter(dbCommand, "ProductFee", DbType.Decimal, model.ProductFee);
			db.AddInParameter(dbCommand, "DerateFee", DbType.Decimal, model.DerateFee);
			db.AddInParameter(dbCommand, "AddressId", DbType.Int32, model.AddressId);
			db.AddInParameter(dbCommand, "RecieverName", DbType.AnsiString, model.RecieverName);
			db.AddInParameter(dbCommand, "RecieverEmail", DbType.AnsiString, model.RecieverEmail);
			db.AddInParameter(dbCommand, "RecieverPhone", DbType.AnsiString, model.RecieverPhone);
			db.AddInParameter(dbCommand, "Postalcode", DbType.AnsiString, model.Postalcode);
			db.AddInParameter(dbCommand, "RecieverCity", DbType.AnsiString, model.RecieverCity);
			db.AddInParameter(dbCommand, "RecieverProvince", DbType.AnsiString, model.RecieverProvince);
			db.AddInParameter(dbCommand, "AddressDetial", DbType.AnsiString, model.AddressDetial);
			db.AddInParameter(dbCommand, "ChangeTime", DbType.DateTime, model.ChangeTime);
			db.AddInParameter(dbCommand, "PayTime", DbType.DateTime, model.PayTime);
			db.AddInParameter(dbCommand, "CreateTime", DbType.DateTime, model.CreateTime);
			db.AddInParameter(dbCommand, "OrderType", DbType.Byte, model.OrderType);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int OrderId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrder_Delete");
			db.AddInParameter(dbCommand, "OrderId", DbType.Int32,OrderId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.OrderModel GetModel(int OrderId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_spOrder_GetModel");
			db.AddInParameter(dbCommand, "OrderId", DbType.Int32,OrderId);

			NoName.NetShop.Model.OrderModel model=null;
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
			strSql.Append("select UserId,OrderId,OrderStatus,PayMethod,ShipMethod,PayStatus,Paysum,ShipFee,ProductFee,DerateFee,AddressId,RecieverName,RecieverEmail,RecieverPhone,Postalcode,RecieverCity,RecieverProvince,AddressDetial,ChangeTime,PayTime,CreateTime,OrderType ");
			strSql.Append(" FROM spOrder ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "spOrder");
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
		public List<NoName.NetShop.Model.OrderModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,OrderId,OrderStatus,PayMethod,ShipMethod,PayStatus,Paysum,ShipFee,ProductFee,DerateFee,AddressId,RecieverName,RecieverEmail,RecieverPhone,Postalcode,RecieverCity,RecieverProvince,AddressDetial,ChangeTime,PayTime,CreateTime,OrderType ");
			strSql.Append(" FROM spOrder ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.OrderModel> list = new List<NoName.NetShop.Model.OrderModel>();
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
		public NoName.NetShop.Model.OrderModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.OrderModel model=new NoName.NetShop.Model.OrderModel();
			object ojb; 
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			ojb = dataReader["OrderId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderId=(int)ojb;
			}
			ojb = dataReader["OrderStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderStatus=(int)ojb;
			}
			ojb = dataReader["PayMethod"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PayMethod=(int)ojb;
			}
			ojb = dataReader["ShipMethod"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ShipMethod=(int)ojb;
			}
			ojb = dataReader["PayStatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PayStatus=(int)ojb;
			}
			ojb = dataReader["Paysum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Paysum=(decimal)ojb;
			}
			ojb = dataReader["ShipFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ShipFee=(decimal)ojb;
			}
			ojb = dataReader["ProductFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductFee=(decimal)ojb;
			}
			ojb = dataReader["DerateFee"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DerateFee=(decimal)ojb;
			}
			ojb = dataReader["AddressId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddressId=(int)ojb;
			}
			model.RecieverName=dataReader["RecieverName"].ToString();
			model.RecieverEmail=dataReader["RecieverEmail"].ToString();
			model.RecieverPhone=dataReader["RecieverPhone"].ToString();
			model.Postalcode=dataReader["Postalcode"].ToString();
			model.RecieverCity=dataReader["RecieverCity"].ToString();
			model.RecieverProvince=dataReader["RecieverProvince"].ToString();
			model.AddressDetial=dataReader["AddressDetial"].ToString();
			ojb = dataReader["ChangeTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ChangeTime=(DateTime)ojb;
			}
			ojb = dataReader["PayTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PayTime=(DateTime)ojb;
			}
			ojb = dataReader["CreateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreateTime=(DateTime)ojb;
			}
			ojb = dataReader["OrderType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderType=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

