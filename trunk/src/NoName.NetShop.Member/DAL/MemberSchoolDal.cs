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
	/// ���ݷ�����MemberSchool��
	/// </summary>
	public class MemberSchool
	{
		public MemberSchool()
		{}
		#region  ��Ա����



		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int userid)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberSchool_Exists");
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);
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
		///  ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Member.Model.MemberSchool model)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberSchool_ADD");
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "truename", DbType.AnsiString, model.truename);
			db.AddInParameter(dbCommand, "duty", DbType.Byte, model.duty);
			db.AddInParameter(dbCommand, "school", DbType.AnsiString, model.school);
			db.AddInParameter(dbCommand, "province", DbType.AnsiString, model.province);
			db.AddInParameter(dbCommand, "city", DbType.AnsiString, model.city);
			db.AddInParameter(dbCommand, "county", DbType.AnsiString, model.county);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "TelePhone", DbType.AnsiString, model.TelePhone);
			db.AddInParameter(dbCommand, "Fax", DbType.AnsiString, model.Fax);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Member.Model.MemberSchool model)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberSchool_Update");
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "truename", DbType.AnsiString, model.truename);
			db.AddInParameter(dbCommand, "duty", DbType.Byte, model.duty);
			db.AddInParameter(dbCommand, "school", DbType.AnsiString, model.school);
			db.AddInParameter(dbCommand, "province", DbType.AnsiString, model.province);
			db.AddInParameter(dbCommand, "city", DbType.AnsiString, model.city);
			db.AddInParameter(dbCommand, "county", DbType.AnsiString, model.county);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "TelePhone", DbType.AnsiString, model.TelePhone);
			db.AddInParameter(dbCommand, "Fax", DbType.AnsiString, model.Fax);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int userid)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberSchool_Delete");
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Member.Model.MemberSchool GetModel(int userid)
		{
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_umMemberSchool_GetModel");
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);

			NoName.NetShop.Member.Model.MemberSchool model=null;
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userid,truename,duty,school,province,city,county,Mobile,TelePhone,Fax,Email ");
			strSql.Append(" FROM umMemberSchool ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}



		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<NoName.NetShop.Member.Model.MemberSchool> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userid,truename,duty,school,province,city,county,Mobile,TelePhone,Fax,Email ");
			strSql.Append(" FROM umMemberSchool ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Member.Model.MemberSchool> list = new List<NoName.NetShop.Member.Model.MemberSchool>();
			Database db = NoName.NetShop.Common.DBFacroty.DbReader;
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
		/// ����ʵ�������
		/// </summary>
		public NoName.NetShop.Member.Model.MemberSchool ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Member.Model.MemberSchool model=new NoName.NetShop.Member.Model.MemberSchool();
			object ojb; 
			ojb = dataReader["userid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userid=(int)ojb;
			}
			model.truename=dataReader["truename"].ToString();
			ojb = dataReader["duty"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.duty=(int)ojb;
			}
			model.school=dataReader["school"].ToString();
			model.province=dataReader["province"].ToString();
			model.city=dataReader["city"].ToString();
			model.county=dataReader["county"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			model.TelePhone=dataReader["TelePhone"].ToString();
			model.Fax=dataReader["Fax"].ToString();
			model.Email=dataReader["Email"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

