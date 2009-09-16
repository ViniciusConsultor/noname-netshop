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
	/// 数据访问类SupplyDemandModelDal。
	/// </summary>
	public class SupplyDemandModelDal
	{
		public SupplyDemandModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(sdId)+1 from sdSupplyDemand";
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
		public bool Exists(int sdId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_sdSupplyDemand_Exists");
			db.AddInParameter(dbCommand, "sdId", DbType.Int32,sdId);
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
		public void Add(NoName.NetShop.Model.SupplyDemandModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_sdSupplyDemand_ADD");
			db.AddInParameter(dbCommand, "sdId", DbType.Int32, model.sdId);
			db.AddInParameter(dbCommand, "sdType", DbType.Byte, model.sdType);
			db.AddInParameter(dbCommand, "userId", DbType.Int32, model.userId);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.SupplyDemandModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_sdSupplyDemand_Update");
			db.AddInParameter(dbCommand, "sdId", DbType.Int32, model.sdId);
			db.AddInParameter(dbCommand, "sdType", DbType.Byte, model.sdType);
			db.AddInParameter(dbCommand, "userId", DbType.Int32, model.userId);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int sdId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_sdSupplyDemand_Delete");
			db.AddInParameter(dbCommand, "sdId", DbType.Int32,sdId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.SupplyDemandModel GetModel(int sdId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_sdSupplyDemand_GetModel");
			db.AddInParameter(dbCommand, "sdId", DbType.Int32,sdId);

			NoName.NetShop.Model.SupplyDemandModel model=null;
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
			strSql.Append("select sdId,sdType,userId,Title,Content,InsertTime,ModifyTime,Status ");
			strSql.Append(" FROM sdSupplyDemand ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "sdSupplyDemand");
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
		public List<NoName.NetShop.Model.SupplyDemandModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sdId,sdType,userId,Title,Content,InsertTime,ModifyTime,Status ");
			strSql.Append(" FROM sdSupplyDemand ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.SupplyDemandModel> list = new List<NoName.NetShop.Model.SupplyDemandModel>();
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
		public NoName.NetShop.Model.SupplyDemandModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.SupplyDemandModel model=new NoName.NetShop.Model.SupplyDemandModel();
			object ojb; 
			ojb = dataReader["sdId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.sdId=(int)ojb;
			}
			ojb = dataReader["sdType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.sdType=(int)ojb;
			}
			ojb = dataReader["userId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userId=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["InsertTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.InsertTime=(DateTime)ojb;
			}
			ojb = dataReader["ModifyTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ModifyTime=(DateTime)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

