using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 数据访问类Category。
	/// </summary>
	public class SSCategoryDal
	{
		public SSCategoryDal()
		{}
		#region  成员方法

		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Solution.SSCategoryModel model)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategory_Save");
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32, model.SenceId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			db.AddInParameter(dbCommand, "CateImage", DbType.AnsiString, model.CateImage);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "Position", DbType.AnsiString, model.Position);
			db.AddInParameter(dbCommand, "IsShow", DbType.Boolean, model.IsShow);
			db.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SenceId,int CateId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategory_Delete");
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32,SenceId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SSCategoryModel GetModel(int SenceId,int CateId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slCategory_GetModel");
			db.AddInParameter(dbCommand, "SenceId", DbType.Int32,SenceId);
			db.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);

			NoName.NetShop.Solution.SSCategoryModel model=null;
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
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<NoName.NetShop.Solution.SSCategoryModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SenceId,CateId,CateImage,Remark,Position,IsShow ");
			strSql.Append(" FROM slCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Solution.SSCategoryModel> list = new List<NoName.NetShop.Solution.SSCategoryModel>();
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
		public NoName.NetShop.Solution.SSCategoryModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Solution.SSCategoryModel model=new NoName.NetShop.Solution.SSCategoryModel();
			object ojb; 
			ojb = dataReader["SenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SenceId=(int)ojb;
			}
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			model.CateImage=dataReader["CateImage"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			model.Position=dataReader["Position"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(bool)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

