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
	/// 数据访问类VoteItemsModelDal。
	/// </summary>
	public class VoteItemsModelDal
	{
		public VoteItemsModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ItemId)+1 from voVoteItems";
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
		public bool Exists(int ItemId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItems_Exists");
			db.AddInParameter(dbCommand, "ItemId", DbType.Int32,ItemId);
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
		public void Add(NoName.NetShop.Model.VoteItemsModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItems_ADD");
			db.AddInParameter(dbCommand, "VoteGroupId", DbType.Int32, model.VoteGroupId);
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "ItemId", DbType.Int32, model.ItemId);
			db.AddInParameter(dbCommand, "ItemContent", DbType.AnsiString, model.ItemContent);
			db.AddInParameter(dbCommand, "VoteCount", DbType.Int32, model.VoteCount);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.VoteItemsModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItems_Update");
			db.AddInParameter(dbCommand, "VoteGroupId", DbType.Int32, model.VoteGroupId);
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "ItemId", DbType.Int32, model.ItemId);
			db.AddInParameter(dbCommand, "ItemContent", DbType.AnsiString, model.ItemContent);
			db.AddInParameter(dbCommand, "VoteCount", DbType.Int32, model.VoteCount);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ItemId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItems_Delete");
			db.AddInParameter(dbCommand, "ItemId", DbType.Int32,ItemId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.VoteItemsModel GetModel(int ItemId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItems_GetModel");
			db.AddInParameter(dbCommand, "ItemId", DbType.Int32,ItemId);

			NoName.NetShop.Model.VoteItemsModel model=null;
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
			strSql.Append("select VoteGroupId,VoteId,ItemId,ItemContent,VoteCount ");
			strSql.Append(" FROM voVoteItems ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "voVoteItems");
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
		public List<NoName.NetShop.Model.VoteItemsModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VoteGroupId,VoteId,ItemId,ItemContent,VoteCount ");
			strSql.Append(" FROM voVoteItems ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.VoteItemsModel> list = new List<NoName.NetShop.Model.VoteItemsModel>();
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
		public NoName.NetShop.Model.VoteItemsModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.VoteItemsModel model=new NoName.NetShop.Model.VoteItemsModel();
			object ojb; 
			ojb = dataReader["VoteGroupId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteGroupId=(int)ojb;
			}
			ojb = dataReader["VoteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteId=(int)ojb;
			}
			ojb = dataReader["ItemId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ItemId=(int)ojb;
			}
			model.ItemContent=dataReader["ItemContent"].ToString();
			ojb = dataReader["VoteCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteCount=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

