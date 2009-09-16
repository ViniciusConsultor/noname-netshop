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
	/// 数据访问类PagesModelDal。
	/// </summary>
	public class PagesModelDal
	{
		public PagesModelDal()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.PagesModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsPages_ADD");
			db.AddInParameter(dbCommand, "PageId", DbType.Int32, model.PageId);
			db.AddInParameter(dbCommand, "TemplateFile", DbType.AnsiString, model.TemplateFile);
			db.AddInParameter(dbCommand, "PageUrl", DbType.AnsiString, model.PageUrl);
			db.AddInParameter(dbCommand, "PagePhyPath", DbType.AnsiString, model.PagePhyPath);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "LastPubTime", DbType.DateTime, model.LastPubTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.PagesModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsPages_Update");
			db.AddInParameter(dbCommand, "PageId", DbType.Int32, model.PageId);
			db.AddInParameter(dbCommand, "TemplateFile", DbType.AnsiString, model.TemplateFile);
			db.AddInParameter(dbCommand, "PageUrl", DbType.AnsiString, model.PageUrl);
			db.AddInParameter(dbCommand, "PagePhyPath", DbType.AnsiString, model.PagePhyPath);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "LastPubTime", DbType.DateTime, model.LastPubTime);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsPages_Delete");

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.PagesModel GetModel()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_cmsPages_GetModel");

			NoName.NetShop.Model.PagesModel model=null;
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
			strSql.Append("select PageId,TemplateFile,PageUrl,PagePhyPath,Status,LastPubTime ");
			strSql.Append(" FROM cmsPages ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "cmsPages");
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
		public List<NoName.NetShop.Model.PagesModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PageId,TemplateFile,PageUrl,PagePhyPath,Status,LastPubTime ");
			strSql.Append(" FROM cmsPages ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.PagesModel> list = new List<NoName.NetShop.Model.PagesModel>();
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
		public NoName.NetShop.Model.PagesModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.PagesModel model=new NoName.NetShop.Model.PagesModel();
			object ojb; 
			ojb = dataReader["PageId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PageId=(int)ojb;
			}
			model.TemplateFile=dataReader["TemplateFile"].ToString();
			model.PageUrl=dataReader["PageUrl"].ToString();
			model.PagePhyPath=dataReader["PagePhyPath"].ToString();
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			ojb = dataReader["LastPubTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LastPubTime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

