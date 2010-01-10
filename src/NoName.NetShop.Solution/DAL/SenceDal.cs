using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Common;
namespace NoName.NetShop.Solution
{
	/// <summary>
	/// 数据访问类Sence。
	/// </summary>
	public class SenceDal
	{
		public SenceDal()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ScenceId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSence_Exists");
			db.AddInParameter(dbCommand, "ScenceId", DbType.Int32,ScenceId);
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
		public void Save(NoName.NetShop.Solution.SenceModel model)
		{
            if (model.ScenceId == 0)
                model.ScenceId = CommDataHelper.GetNewSerialNum(AppType.Solution);

			Database db = CommDataAccess.DbWriter;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSence_Save");
			db.AddInParameter(dbCommand, "ScenceId", DbType.Int32, model.ScenceId);
			db.AddInParameter(dbCommand, "ScenceName", DbType.AnsiString, model.ScenceName);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "SenceImg", DbType.AnsiString, model.SenceImg);
			db.AddInParameter(dbCommand, "SenceType", DbType.Byte, model.SenceType);
			db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, model.IsActive);
			db.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Solution.SenceModel GetModel(int ScenceId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_slSence_GetModel");
			db.AddInParameter(dbCommand, "ScenceId", DbType.Int32,ScenceId);

			NoName.NetShop.Solution.SenceModel model=null;
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
		public List<NoName.NetShop.Solution.SenceModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ScenceId,ScenceName,Remark,SenceImg,SenceType,IsActive ");
			strSql.Append(" FROM slSence ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Solution.SenceModel> list = new List<NoName.NetShop.Solution.SenceModel>();
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
		public NoName.NetShop.Solution.SenceModel ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Solution.SenceModel model=new NoName.NetShop.Solution.SenceModel();
			object ojb; 
			ojb = dataReader["ScenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ScenceId=(int)ojb;
			}
			model.ScenceName=dataReader["ScenceName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			model.SenceImg=dataReader["SenceImg"].ToString();
			ojb = dataReader["SenceType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SenceType=(int)ojb;
			}
			ojb = dataReader["IsActive"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsActive=(bool)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

