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
	/// 数据访问类VoteTopic。
	/// </summary>
	public class VoteTopic
	{
		public VoteTopic()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteTopic model)
		{
            if (model.VoteId == 0)
                model.VoteId = NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Other);

            Database db = DBFactory.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteTopic_Save");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "Topic", DbType.AnsiString, model.Topic);
			db.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "EndTime", DbType.DateTime, model.EndTime);
			db.AddInParameter(dbCommand, "IsRegUser", DbType.Boolean, model.IsRegUser);
			db.AddInParameter(dbCommand, "Status", DbType.Boolean, model.Status);
            db.AddInParameter(dbCommand, "IsMulti", DbType.Boolean, model.IsMulti);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int VoteId)
		{
            Database db = DBFactory.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteTopic_Delete");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32,VoteId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteTopic GetModel(int VoteId)
		{
            Database db = DBFactory.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteTopic_GetModel");
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32,VoteId);

			NoName.NetShop.Vote.Model.VoteTopic model=null;
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
		/// 对象实体绑定数据
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteTopic ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Vote.Model.VoteTopic model=new NoName.NetShop.Vote.Model.VoteTopic();
			object ojb; 
			ojb = dataReader["VoteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteId=(int)ojb;
			}
			model.Topic=dataReader["Topic"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["StartTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartTime=(DateTime)ojb;
			}
			ojb = dataReader["EndTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndTime=(DateTime)ojb;
			}
			ojb = dataReader["VoteUserNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteUserNum=(int)ojb;
			}
			ojb = dataReader["IsRegUser"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsRegUser=(bool)ojb;
			}
            ojb = dataReader["status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = (bool)ojb;
            }
            ojb = dataReader["IsMulti"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsMulti = (bool)ojb;
            } return model;
		}

		#endregion  成员方法
	}
}

