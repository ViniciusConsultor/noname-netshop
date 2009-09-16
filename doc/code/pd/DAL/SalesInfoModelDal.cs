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
	/// 数据访问类SalesInfoModelDal。
	/// </summary>
	public class SalesInfoModelDal
	{
		public SalesInfoModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SalesType)+1 from pdSalesInfo";
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
		public bool Exists(int SalesType,int ProductId,int RuleType)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdSalesInfo_Exists");
			db.AddInParameter(dbCommand, "SalesType", DbType.Byte,SalesType);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			db.AddInParameter(dbCommand, "RuleType", DbType.Byte,RuleType);
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
		public void Add(NoName.NetShop.Model.SalesInfoModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdSalesInfo_ADD");
			db.AddInParameter(dbCommand, "SalesType", DbType.Byte, model.SalesType);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "RuleType", DbType.Byte, model.RuleType);
			db.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.SalesInfoModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdSalesInfo_Update");
			db.AddInParameter(dbCommand, "SalesType", DbType.Byte, model.SalesType);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			db.AddInParameter(dbCommand, "RuleType", DbType.Byte, model.RuleType);
			db.AddInParameter(dbCommand, "SortValue", DbType.Int32, model.SortValue);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SalesType,int ProductId,int RuleType)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdSalesInfo_Delete");
			db.AddInParameter(dbCommand, "SalesType", DbType.Byte,SalesType);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			db.AddInParameter(dbCommand, "RuleType", DbType.Byte,RuleType);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.SalesInfoModel GetModel(int SalesType,int ProductId,int RuleType)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdSalesInfo_GetModel");
			db.AddInParameter(dbCommand, "SalesType", DbType.Byte,SalesType);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			db.AddInParameter(dbCommand, "RuleType", DbType.Byte,RuleType);

			NoName.NetShop.Model.SalesInfoModel model=null;
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
			strSql.Append("select SalesType,ProductId,RuleType,SortValue ");
			strSql.Append(" FROM pdSalesInfo ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdSalesInfo");
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
		public List<NoName.NetShop.Model.SalesInfoModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SalesType,ProductId,RuleType,SortValue ");
			strSql.Append(" FROM pdSalesInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.SalesInfoModel> list = new List<NoName.NetShop.Model.SalesInfoModel>();
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
		public NoName.NetShop.Model.SalesInfoModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.SalesInfoModel model=new NoName.NetShop.Model.SalesInfoModel();
			object ojb; 
			ojb = dataReader["SalesType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SalesType=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["RuleType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RuleType=(int)ojb;
			}
			ojb = dataReader["SortValue"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SortValue=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

