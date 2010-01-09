using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using NoName.NetShop.Common;
namespace NoName.NetShop.Vote.DAL
{
	/// <summary>
	/// ���ݷ�����VoteRemark��
	/// </summary>
	public class VoteRemark
	{
		public VoteRemark()
		{}
		#region  ��Ա����


		/// <summary>
		///  ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Vote.Model.VoteRemark model)
		{
            if (model.LogId == 0)
            {
                model.LogId = NoName.NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Other);
            }

            Database db = CommDataAccess.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_ADD");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "UserId", DbType.String, model.UserId);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "VoteIP", DbType.AnsiString, model.VoteIP);
			db.AddInParameter(dbCommand, "LogId", DbType.Int32, model.LogId);
            db.AddInParameter(dbCommand, "ItemIds", DbType.AnsiString, model.ItemIds);
            db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// ����û��Ƿ����ͶƱ
        /// �����ע���û����������ظ�ͶƱ
        /// ����Ƿ�ע���ͶƱ����ͬһip20�����ڲ�����ͶƱ
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="voteId"></param>
        /// <returns></returns>
        public bool Validate(int voteId,string userId, string voteIp)
        {
            Database db = CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_Validate");
            db.AddInParameter(dbCommand, "VoteId", DbType.Int32, voteId);
            db.AddInParameter(dbCommand, "UserId", DbType.String, userId);
            db.AddInParameter(dbCommand, "VoteIP", DbType.String, voteIp);
            db.AddOutParameter(dbCommand, "result", DbType.Int32,4);
            db.ExecuteNonQuery(dbCommand);
            int result = Convert.ToInt32(db.GetParameterValue(dbCommand, "result"));
            return result == 0;
        }


		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int LogId)
		{
            Database db = CommDataAccess.DbWriter;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_Delete");
			db.AddInParameter(dbCommand, "LogId", DbType.Int32,LogId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteRemark GetModel(int LogId)
		{
            Database db = CommDataAccess.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteRemark_GetModel");
			db.AddInParameter(dbCommand, "LogId", DbType.Int32,LogId);

			NoName.NetShop.Vote.Model.VoteRemark model=null;
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
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<NoName.NetShop.Vote.Model.VoteRemark> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VoteId,UserId,Remark,VoteTime,VoteIP,LogId,itemids ");
			strSql.Append(" FROM voVoteRemark ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Vote.Model.VoteRemark> list = new List<NoName.NetShop.Vote.Model.VoteRemark>();
            Database db = CommDataAccess.DbReader;
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
		public NoName.NetShop.Vote.Model.VoteRemark ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Vote.Model.VoteRemark model=new NoName.NetShop.Vote.Model.VoteRemark();
			object ojb; 
			ojb = dataReader["VoteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteId=(int)ojb;
			}
			model.UserId = dataReader["UserId"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["VoteTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteTime=(DateTime)ojb;
			}
			model.VoteIP=dataReader["VoteIP"].ToString();
			ojb = dataReader["LogId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LogId=(int)ojb;
			}
            model.ItemIds = dataReader["itemids"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

