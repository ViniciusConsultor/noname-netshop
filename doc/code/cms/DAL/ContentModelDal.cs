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
	/// 数据访问类ContentModelDal。
	/// </summary>
	public class ContentModelDal
	{
		public ContentModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CmsTagId)+1 from cmsContent";
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
		public bool Exists(int CmsTagId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsContent_Exists");
			db.AddInParameter(dbCommand, "CmsTagId", DbType.Int32,CmsTagId);
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
		public void Add(NoName.NetShop.Model.ContentModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsContent_ADD");
			db.AddInParameter(dbCommand, "CmsTagId", DbType.Int32, model.CmsTagId);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
			db.AddInParameter(dbCommand, "LastModifyTime", DbType.DateTime, model.LastModifyTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.ContentModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsContent_Update");
			db.AddInParameter(dbCommand, "CmsTagId", DbType.Int32, model.CmsTagId);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
			db.AddInParameter(dbCommand, "LastModifyTime", DbType.DateTime, model.LastModifyTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CmsTagId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsContent_Delete");
			db.AddInParameter(dbCommand, "CmsTagId", DbType.Int32,CmsTagId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.ContentModel GetModel(int CmsTagId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsContent_GetModel");
			db.AddInParameter(dbCommand, "CmsTagId", DbType.Int32,CmsTagId);

			NoName.NetShop.Model.ContentModel model=null;
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
			strSql.Append("select CmsTagId,Content,LastModifyTime ");
			strSql.Append(" FROM cmsContent ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "cmsContent");
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
		public List<NoName.NetShop.Model.ContentModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CmsTagId,Content,LastModifyTime ");
			strSql.Append(" FROM cmsContent ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.ContentModel> list = new List<NoName.NetShop.Model.ContentModel>();
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
		public NoName.NetShop.Model.ContentModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.ContentModel model=new NoName.NetShop.Model.ContentModel();
			object ojb; 
			ojb = dataReader["CmsTagId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CmsTagId=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["LastModifyTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LastModifyTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

