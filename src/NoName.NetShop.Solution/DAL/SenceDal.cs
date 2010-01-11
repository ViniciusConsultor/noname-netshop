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
	/// ���ݷ�����Sence��
	/// </summary>
	public class SenceDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public SenceDal()
		{
        }
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ScenceId)
		{			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_slSence_Exists");
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
		///  ����һ������
		/// </summary>
		public void Save(SenceModel model)
		{
            if (model.ScenceId == 0)
                model.ScenceId = CommDataHelper.GetNewSerialNum(AppType.Solution);

			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slSence_Save");
			dbw.AddInParameter(dbCommand, "ScenceId", DbType.Int32, model.ScenceId);
			dbw.AddInParameter(dbCommand, "ScenceName", DbType.AnsiString, model.ScenceName);
			dbw.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			dbw.AddInParameter(dbCommand, "SenceImg", DbType.AnsiString, model.SenceImg);
			dbw.AddInParameter(dbCommand, "SenceType", DbType.Byte, model.SenceType);
			dbw.AddInParameter(dbCommand, "IsActive", DbType.Boolean, model.IsActive);
			dbw.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SenceModel GetModel(int ScenceId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_slSence_GetModel");
			dbr.AddInParameter(dbCommand, "ScenceId", DbType.Int32,ScenceId);

			SenceModel model=null;
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
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<SenceModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ScenceId,ScenceName,Remark,SenceImg,SenceType,IsActive ");
			strSql.Append(" FROM slSence ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<SenceModel> list = new List<SenceModel>();
			
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
		/// ����ʵ�������
		/// </summary>
		public SenceModel ReaderBind(IDataReader dataReader)
		{
			SenceModel model=new SenceModel();
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

		#endregion  ��Ա����
	}
}

