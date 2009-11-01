using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.News.Model;//请先添加引用

namespace NoName.NetShop.News.DAL
{
	/// <summary>
	/// 数据访问类NewsModelDal。
	/// </summary>
	public class NewsModelDal
	{
        public NewsModelDal()
        { }
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(NewsId)+1 from neNews";
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
		public bool Exists(int NewsId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_neNews_Exists");
			db.AddInParameter(dbCommand, "NewsId", DbType.Int32,NewsId);
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
		public void Add(NewsModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_neNews_ADD");
			db.AddInParameter(dbCommand, "NewsId", DbType.Int32, model.NewsId);
			db.AddInParameter(dbCommand, "NewsType", DbType.Byte, model.NewsType);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "SubTitle", DbType.AnsiString, model.SubTitle);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
			db.AddInParameter(dbCommand, "SmallImageUrl", DbType.AnsiString, model.SmallImageUrl);
			db.AddInParameter(dbCommand, "Author", DbType.AnsiString, model.Author);
			db.AddInParameter(dbCommand, "From", DbType.AnsiString, model.From);
			db.AddInParameter(dbCommand, "VideoUrl", DbType.AnsiString, model.VideoUrl);
			db.AddInParameter(dbCommand, "ImageUrl", DbType.AnsiString, model.ImageUrl);
			db.AddInParameter(dbCommand, "ProductId", DbType.AnsiString, model.ProductId);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
			db.AddInParameter(dbCommand, "Tags", DbType.AnsiString, model.Tags);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NewsModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_neNews_Update");
			db.AddInParameter(dbCommand, "NewsId", DbType.Int32, model.NewsId);
			db.AddInParameter(dbCommand, "NewsType", DbType.Byte, model.NewsType);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			db.AddInParameter(dbCommand, "SubTitle", DbType.AnsiString, model.SubTitle);
			db.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
			db.AddInParameter(dbCommand, "SmallImageUrl", DbType.AnsiString, model.SmallImageUrl);
			db.AddInParameter(dbCommand, "Author", DbType.AnsiString, model.Author);
			db.AddInParameter(dbCommand, "From", DbType.AnsiString, model.From);
			db.AddInParameter(dbCommand, "VideoUrl", DbType.AnsiString, model.VideoUrl);
			db.AddInParameter(dbCommand, "ImageUrl", DbType.AnsiString, model.ImageUrl);
			db.AddInParameter(dbCommand, "ProductId", DbType.AnsiString, model.ProductId);
			db.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			db.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
			db.AddInParameter(dbCommand, "Tags", DbType.AnsiString, model.Tags);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int NewsId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_neNews_Delete");
			db.AddInParameter(dbCommand, "NewsId", DbType.Int32,NewsId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NewsModel GetModel(int NewsId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_neNews_GetModel");
			db.AddInParameter(dbCommand, "NewsId", DbType.Int32,NewsId);

			NewsModel model=null;
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
			strSql.Append("select NewsId,NewsType,Status,Title,SubTitle,Brief,Content,SmallImageUrl,Author,From,VideoUrl,ImageUrl,ProductId,InsertTime,ModifyTime,Tags ");
			strSql.Append(" FROM neNews ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "neNews");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NewsModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select NewsId,NewsType,Status,Title,SubTitle,Brief,Content,SmallImageUrl,Author,From,VideoUrl,ImageUrl,ProductId,InsertTime,ModifyTime,Tags ");
			strSql.Append(" FROM neNews ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NewsModel> list = new List<NewsModel>();
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
		public NewsModel ReaderBind(IDataReader dataReader)
		{
			NewsModel model=new NewsModel();
			object ojb; 
			ojb = dataReader["NewsId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NewsId=(int)ojb;
			}
			ojb = dataReader["NewsType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NewsType=(int)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.SubTitle=dataReader["SubTitle"].ToString();
			model.Brief=dataReader["Brief"].ToString();
			model.Content=dataReader["Content"].ToString();
			model.SmallImageUrl=dataReader["SmallImageUrl"].ToString();
			model.Author=dataReader["Author"].ToString();
			model.From=dataReader["From"].ToString();
			model.VideoUrl=dataReader["VideoUrl"].ToString();
			model.ImageUrl=dataReader["ImageUrl"].ToString();
			model.ProductId=dataReader["ProductId"].ToString();
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
			model.Tags=dataReader["Tags"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

