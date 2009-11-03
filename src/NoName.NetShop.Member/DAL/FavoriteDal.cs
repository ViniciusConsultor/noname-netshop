using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace NoName.NetShop.Member.DAL
{
	/// <summary>
	/// 数据访问类Favorite。
	/// </summary>
	public class Favorite
	{
		public Favorite()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Member.Model.Favorite model)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
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
		public void Update(NoName.NetShop.Member.Model.Favorite model)
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
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
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_Delete");

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Member.Model.Favorite GetModel()
		{
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umFavorite_GetModel");

			NoName.NetShop.Member.Model.Favorite model=null;
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
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}


		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NoName.NetShop.Member.Model.Favorite> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserId,FavoriteId,FavoriteUrl,FavoriteName,InsertTime,ContentId,ContentType ");
			strSql.Append(" FROM umFavorite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Member.Model.Favorite> list = new List<NoName.NetShop.Member.Model.Favorite>();
			Database db = NoName.NetShop.Common.CommDataAccess.DbReader;
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
		public NoName.NetShop.Member.Model.Favorite ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Member.Model.Favorite model=new NoName.NetShop.Member.Model.Favorite();
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

