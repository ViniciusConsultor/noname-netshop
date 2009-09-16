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
	/// 数据访问类FavoriteModelDal。
	/// </summary>
	public class FavoriteModelDal
	{
		public FavoriteModelDal()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Model.FavoriteModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_ADD");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "FavoriteId", DbType.Int32, model.FavoriteId);
			db.AddInParameter(dbCommand, "FavoriteUrl", DbType.AnsiString, model.FavoriteUrl);
			db.AddInParameter(dbCommand, "FavoriteName", DbType.AnsiString, model.FavoriteName);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ContentId", DbType.Int32, model.ContentId);
			db.AddInParameter(dbCommand, "ContentType", DbType.Byte, model.ContentType);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NoName.NetShop.Model.FavoriteModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_Update");
			db.AddInParameter(dbCommand, "UserId", DbType.Int32, model.UserId);
			db.AddInParameter(dbCommand, "FavoriteId", DbType.Int32, model.FavoriteId);
			db.AddInParameter(dbCommand, "FavoriteUrl", DbType.AnsiString, model.FavoriteUrl);
			db.AddInParameter(dbCommand, "FavoriteName", DbType.AnsiString, model.FavoriteName);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ContentId", DbType.Int32, model.ContentId);
			db.AddInParameter(dbCommand, "ContentType", DbType.Byte, model.ContentType);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_Delete");

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Model.FavoriteModel GetModel()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_GetModel");

			NoName.NetShop.Model.FavoriteModel model=null;
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
			strSql.Append("select UserId,FavoriteId,FavoriteUrl,FavoriteName,InsertTime,ContentId,ContentType ");
			strSql.Append(" FROM umFavorite ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "umFavorite");
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
		public List<NoName.NetShop.Model.FavoriteModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,FavoriteId,FavoriteUrl,FavoriteName,InsertTime,ContentId,ContentType ");
			strSql.Append(" FROM umFavorite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Model.FavoriteModel> list = new List<NoName.NetShop.Model.FavoriteModel>();
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
		public NoName.NetShop.Model.FavoriteModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Model.FavoriteModel model=new NoName.NetShop.Model.FavoriteModel();
			object ojb; 
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			ojb = dataReader["FavoriteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FavoriteId=(int)ojb;
			}
			model.FavoriteUrl=dataReader["FavoriteUrl"].ToString();
			model.FavoriteName=dataReader["FavoriteName"].ToString();
			ojb = dataReader["InsertTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.InsertTime=(DateTime)ojb;
			}
			ojb = dataReader["ContentId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ContentId=(int)ojb;
			}
			ojb = dataReader["ContentType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ContentType=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

