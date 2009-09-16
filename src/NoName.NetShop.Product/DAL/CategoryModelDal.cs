using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Product.Model;


namespace NoName.NetShop.Product.DAL
{
	/// <summary>
	/// 数据访问类CategoryModelDal。
	/// </summary>
	public class CategoryModelDal
	{
		public CategoryModelDal()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CateId)+1 from pdCategory";
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
		public bool Exists(int CateId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategory_Exists");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);
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
		public void Add(CategoryModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategory_ADD");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "CateName", DbType.AnsiString, model.CateName);
			db.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "PriceRange", DbType.AnsiString, model.PriceRange);
			db.AddInParameter(dbCommand, "IsHide", DbType.Boolean, model.IsHide);
			db.AddInParameter(dbCommand, "CateLevel", DbType.Byte, model.CateLevel);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(CategoryModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategory_Update");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "CateName", DbType.AnsiString, model.CateName);
			db.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "PriceRange", DbType.AnsiString, model.PriceRange);
			db.AddInParameter(dbCommand, "IsHide", DbType.Boolean, model.IsHide);
			db.AddInParameter(dbCommand, "CateLevel", DbType.Byte, model.CateLevel);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CateId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategory_Delete");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CategoryModel GetModel(int CateId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategory_GetModel");
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);

			CategoryModel model=null;
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
			strSql.Append("select CateId,CateName,CatePath,Status,PriceRange,IsHide,CateLevel ");
			strSql.Append(" FROM pdCategory ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdCategory");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CategoryModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CateId,CateName,CatePath,Status,PriceRange,IsHide,CateLevel ");
			strSql.Append(" FROM pdCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<CategoryModel> list = new List<CategoryModel>();
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
		public CategoryModel ReaderBind(IDataReader dataReader)
		{
			CategoryModel model=new CategoryModel();
			object ojb; 
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			model.CateName=dataReader["CateName"].ToString();
			model.CatePath=dataReader["CatePath"].ToString();
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			model.PriceRange=dataReader["PriceRange"].ToString();
			ojb = dataReader["IsHide"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsHide=(bool)ojb;
			}
			ojb = dataReader["CateLevel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateLevel=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

