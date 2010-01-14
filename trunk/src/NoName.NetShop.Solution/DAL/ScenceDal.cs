using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Common;
using NoName.NetShop.Solution.Model;

namespace NoName.NetShop.Solution.DAL
{
	/// <summary>
	/// 数据访问类Sence。
	/// </summary>
	public class ScenceDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public ScenceDal()
		{
        }
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ScenceId)
		{			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_slScence_Exists");
			dbr.AddInParameter(dbCommand, "ScenceId", DbType.Int32,ScenceId);
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
		public void Save(ScenceModel model)
		{
            if (model.ScenceId == 0)
                model.ScenceId = CommDataHelper.GetNewSerialNum(AppType.Solution);

			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slScence_Save");
			dbw.AddInParameter(dbCommand, "ScenceId", DbType.Int32, model.ScenceId);
			dbw.AddInParameter(dbCommand, "ScenceName", DbType.AnsiString, model.ScenceName);
			dbw.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			dbw.AddInParameter(dbCommand, "SenceImg", DbType.AnsiString, model.SenceImg);
			dbw.AddInParameter(dbCommand, "SenceType", DbType.Byte, model.SenceType);
			dbw.AddInParameter(dbCommand, "IsActive", DbType.Boolean, model.IsActive);
			dbw.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ScenceModel GetModel(int ScenceId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_slScence_GetModel");
			dbr.AddInParameter(dbCommand, "ScenceId", DbType.Int32,ScenceId);

			ScenceModel model=null;
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
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<ScenceModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ScenceId,ScenceName,Remark,SenceImg,SenceType,IsActive ");
			strSql.Append(" FROM slScence ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<ScenceModel> list = new List<ScenceModel>();
			
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
		public ScenceModel ReaderBind(IDataReader dataReader)
		{
			ScenceModel model=new ScenceModel();
			object ojb; 
			ojb = dataReader["ScenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ScenceId=Convert.ToInt32(ojb);
			}
			model.ScenceName=dataReader["ScenceName"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			model.SenceImg=dataReader["SenceImg"].ToString();
			ojb = dataReader["SenceType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SenceType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["IsActive"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsActive=Convert.ToBoolean(ojb);
			}
			return model;
		}

        internal void ToggleStatus(int scenceId)
        {
            string sql = "update slScence set IsActive=case IsActive when 1 then 0 else 1 end where ScenceId=" + scenceId;
            Database db = CommDataAccess.DbWriter;
            db.ExecuteNonQuery(CommandType.Text, sql);
        }

		#endregion  成员方法
	}
}

