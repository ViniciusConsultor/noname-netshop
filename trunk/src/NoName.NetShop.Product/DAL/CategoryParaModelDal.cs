using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Product.Model;
using NoName.NetShop.Common;

namespace NoName.NetShop.Product.DAL
{
	/// <summary>
	/// 数据访问类CategoryParaModelDal。
	/// </summary>
	public class CategoryParaModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public CategoryParaModelDal()
		{}

		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ParaId)+1 from pdCategoryPara";
			
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
		public bool Exists(int ParaId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdCategoryPara_Exists");
			dbr.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);
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
		public void Add(CategoryParaModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdCategoryPara_ADD");
			dbw.AddInParameter(dbCommand, "ParaId", DbType.Int32, model.ParaId);
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			dbw.AddInParameter(dbCommand, "ParaName", DbType.AnsiString, model.ParaName);
			dbw.AddInParameter(dbCommand, "ParaType", DbType.Byte, model.ParaType);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.AddInParameter(dbCommand, "ParaGroupId", DbType.Int32, model.ParaGroupId);
			dbw.AddInParameter(dbCommand, "ParaValues", DbType.AnsiString, model.ParaValues);
			dbw.AddInParameter(dbCommand, "DefaultValue", DbType.AnsiString, model.DefaultValue);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(CategoryParaModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdCategoryPara_Update");
			dbw.AddInParameter(dbCommand, "ParaId", DbType.Int32, model.ParaId);
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			dbw.AddInParameter(dbCommand, "ParaName", DbType.AnsiString, model.ParaName);
			dbw.AddInParameter(dbCommand, "ParaType", DbType.Byte, model.ParaType);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.AddInParameter(dbCommand, "ParaGroupId", DbType.Int32, model.ParaGroupId);
			dbw.AddInParameter(dbCommand, "ParaValues", DbType.AnsiString, model.ParaValues);
			dbw.AddInParameter(dbCommand, "DefaultValue", DbType.AnsiString, model.DefaultValue);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ParaId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdCategoryPara_Delete");
			dbw.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CategoryParaModel GetModel(int ParaId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdCategoryPara_GetModel");
			dbr.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);

			CategoryParaModel model=null;
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
			strSql.Append("select ParaId,CateId,ParaName,ParaType,Status,ParaGroupId,ParaValues,DefaultValue ");
			strSql.Append(" FROM pdCategoryPara ");
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
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdCategoryPara");
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
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
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

