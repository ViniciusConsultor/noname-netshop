using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.News.Model;
using NoName.NetShop.Common;//请先添加引用

namespace NoName.NetShop.News.DAL
{
	/// <summary>
	/// 数据访问类NewsModelDal。
	/// </summary>
	public class NewsModelDal
	{
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public NewsModelDal()
        { }
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(NewsId)+1 from neNews";
			object obj = dbr.ExecuteScalar(CommandType.Text, strsql);
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
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_neNews_Exists");
			dbr.AddInParameter(dbCommand, "NewsId", DbType.Int32,NewsId);
			int result;
			object obj = dbr.ExecuteScalar(dbCommand);
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
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_neNews_ADD");
			dbw.AddInParameter(dbCommand, "NewsId", DbType.Int32, model.NewsId);
			dbw.AddInParameter(dbCommand, "NewsType", DbType.Byte, model.NewsType);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			dbw.AddInParameter(dbCommand, "SubTitle", DbType.AnsiString, model.SubTitle);
			dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			dbw.AddInParameter(dbCommand, "newsContent", DbType.String, model.Content);
			dbw.AddInParameter(dbCommand, "SmallImageUrl", DbType.AnsiString, model.SmallImageUrl);
			dbw.AddInParameter(dbCommand, "Author", DbType.AnsiString, model.Author);
			dbw.AddInParameter(dbCommand, "newsfrom", DbType.AnsiString, model.From);
			dbw.AddInParameter(dbCommand, "VideoUrl", DbType.AnsiString, model.VideoUrl);
			dbw.AddInParameter(dbCommand, "ImageUrl", DbType.AnsiString, model.ImageUrl);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.AnsiString, model.ProductId);
			dbw.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			dbw.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
            dbw.AddInParameter(dbCommand, "Tags", DbType.AnsiString, model.Tags);
            dbw.AddInParameter(dbCommand, "cateid", DbType.Int32, model.CategoryID);



			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(NewsModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_neNews_Update");
			dbw.AddInParameter(dbCommand, "NewsId", DbType.Int32, model.NewsId);
			dbw.AddInParameter(dbCommand, "NewsType", DbType.Byte, model.NewsType);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.AddInParameter(dbCommand, "Title", DbType.AnsiString, model.Title);
			dbw.AddInParameter(dbCommand, "SubTitle", DbType.AnsiString, model.SubTitle);
			dbw.AddInParameter(dbCommand, "Brief", DbType.AnsiString, model.Brief);
			dbw.AddInParameter(dbCommand, "newsContent", DbType.String, model.Content);
			dbw.AddInParameter(dbCommand, "SmallImageUrl", DbType.AnsiString, model.SmallImageUrl);
			dbw.AddInParameter(dbCommand, "Author", DbType.AnsiString, model.Author);
			dbw.AddInParameter(dbCommand, "newsFrom", DbType.AnsiString, model.From);
			dbw.AddInParameter(dbCommand, "VideoUrl", DbType.AnsiString, model.VideoUrl);
			dbw.AddInParameter(dbCommand, "ImageUrl", DbType.AnsiString, model.ImageUrl);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.AnsiString, model.ProductId);
			dbw.AddInParameter(dbCommand, "InsertTime", DbType.DateTime, model.InsertTime);
			dbw.AddInParameter(dbCommand, "ModifyTime", DbType.DateTime, model.ModifyTime);
            dbw.AddInParameter(dbCommand, "Tags", DbType.AnsiString, model.Tags);
            dbw.AddInParameter(dbCommand, "cateid", DbType.Int32, model.CategoryID);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int NewsId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_neNews_Delete");
			dbw.AddInParameter(dbCommand, "NewsId", DbType.Int32,NewsId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NewsModel GetModel(int NewsId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_neNews_GetModel");
			dbr.AddInParameter(dbCommand, "NewsId", DbType.Int32,NewsId);

			NewsModel model=null;
			using (IDataReader dataReader = dbr.ExecuteReader(dbCommand))
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
			strSql.Append("select NewsId,NewsType,Status,Title,SubTitle,Brief,Content,SmallImageUrl,Author,From,VideoUrl,ImageUrl,ProductId,InsertTime,ModifyTime,Tags,cateid ");
			strSql.Append(" FROM neNews ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            
            DbCommand dbCommand = dbr.GetStoredProcCommand("UP_GetRecordByPage");
            dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "neNews");
            dbr.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
            dbr.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            dbr.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            dbr.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            dbr.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            dbr.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return dbr.ExecuteDataSet(dbCommand);
        }

        /// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NewsModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select NewsId,NewsType,Status,Title,SubTitle,Brief,Content,SmallImageUrl,Author,From,VideoUrl,ImageUrl,ProductId,InsertTime,ModifyTime,Tags,cateid ");
			strSql.Append(" FROM neNews ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NewsModel> list = new List<NewsModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}

        public void SetSplendid(int NewsID,bool IsSplendid)
        {
            DbCommand Command = dbw.GetStoredProcCommand("UP_neNews_SetSplendid");

            dbw.AddInParameter(Command,"@NewsID",DbType.Int32,NewsID);
            dbw.AddInParameter(Command,"@IsSplendid",DbType.Boolean,IsSplendid);
            dbw.AddInParameter(Command, "@ModifyTime", DbType.DateTime, DateTime.Now);

            dbw.ExecuteNonQuery(Command);
        }
        
        public DataTable GetTopViewedNews(int TopNumber)
        {
            string sql = "select top {0} * from [nenews] order by [pageview] desc";
            sql = String.Format(sql, TopNumber);
            return dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetTopSplendidNews(int TopNumber)
        {
            string sql = "select top {0} * from [nenews] where [issplendid]=1 order by [modifytime] desc";
            sql = String.Format(sql, TopNumber);
            return dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

        public DataTable GetTopCategoryNews(int TopNumber, int CategoryID)
        {
            string sql = "select top {0} * from [nenews] where dbo.GetNewsCategoryPath(cateid)+'/%' like dbo.GetNewsCategoryPath({1})+'/%' order by [newsid] desc";
            sql = String.Format(sql, TopNumber, CategoryID);
            return dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
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
				model.NewsId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["NewsType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NewsType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.Status = Convert.ToInt32(ojb);
			}
			model.Title=dataReader["Title"].ToString();
			model.SubTitle=dataReader["SubTitle"].ToString();
			model.Brief=dataReader["Brief"].ToString();
			model.SmallImageUrl=dataReader["SmallImageUrl"].ToString();
			model.Author=dataReader["Author"].ToString();
			model.From=dataReader["newsFrom"].ToString();
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
            model.CategoryID = Convert.ToInt32(dataReader["cateid"]);
            model.Content = Convert.ToString(dataReader["newscontent"]);
			return model;
		}

		#endregion  成员方法
	}
}

