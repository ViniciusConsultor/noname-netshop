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
	/// 数据访问类CategoryParaModelDal。
	/// </summary>
	public class CategoryParaModelDal
	{
		public CategoryParaModelDal()
		{}

		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ParaId)+1 from pdCategoryPara";
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
		public bool Exists(int ParaId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategoryPara_Exists");
			db.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);
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
		public void Add(CategoryParaModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategoryPara_ADD");
			db.AddInParameter(dbCommand, "ParaId", DbType.Int32, model.ParaId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "ParaName", DbType.AnsiString, model.ParaName);
			db.AddInParameter(dbCommand, "ParaType", DbType.Byte, model.ParaType);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "ParaGroupId", DbType.Int32, model.ParaGroupId);
			db.AddInParameter(dbCommand, "ParaValues", DbType.AnsiString, model.ParaValues);
			db.AddInParameter(dbCommand, "DefaultValue", DbType.AnsiString, model.DefaultValue);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(CategoryParaModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategoryPara_Update");
			db.AddInParameter(dbCommand, "ParaId", DbType.Int32, model.ParaId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "ParaName", DbType.AnsiString, model.ParaName);
			db.AddInParameter(dbCommand, "ParaType", DbType.Byte, model.ParaType);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "ParaGroupId", DbType.Int32, model.ParaGroupId);
			db.AddInParameter(dbCommand, "ParaValues", DbType.AnsiString, model.ParaValues);
			db.AddInParameter(dbCommand, "DefaultValue", DbType.AnsiString, model.DefaultValue);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ParaId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategoryPara_Delete");
			db.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CategoryParaModel GetModel(int ParaId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_pdCategoryPara_GetModel");
			db.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);

			CategoryParaModel model=null;
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
			strSql.Append("select ParaId,CateId,ParaName,ParaType,Status,ParaGroupId,ParaValues,DefaultValue ");
			strSql.Append(" FROM pdCategoryPara ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdCategoryPara");
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
		public List<CategoryParaModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ParaId,CateId,ParaName,ParaType,Status,ParaGroupId,ParaValues,DefaultValue ");
			strSql.Append(" FROM pdCategoryPara ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<CategoryParaModel> list = new List<CategoryParaModel>();
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
		public CategoryParaModel ReaderBind(IDataReader dataReader)
		{
			CategoryParaModel model=new CategoryParaModel();
			object ojb; 
			ojb = dataReader["ParaId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ParaId=(int)ojb;
			}
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			model.ParaName=dataReader["ParaName"].ToString();
			ojb = dataReader["ParaType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ParaType=(int)ojb;
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			ojb = dataReader["ParaGroupId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ParaGroupId=(int)ojb;
			}
			model.ParaValues=dataReader["ParaValues"].ToString();
			model.DefaultValue=dataReader["DefaultValue"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

