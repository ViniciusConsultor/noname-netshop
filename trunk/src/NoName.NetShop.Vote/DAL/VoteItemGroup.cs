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
	/// ���ݷ�����VoteItemGroup��
	/// </summary>
	public class VoteItemGroup
	{
		public VoteItemGroup()
		{}
		#region  ��Ա����

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteItemGroup model)
		{
            if (model.ItemGroupId == 0)
            {
                model.ItemGroupId = NoName.NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Other);
            }
            Database db = DBFactory.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItemGroup_Save");
			db.AddInParameter(dbCommand, "ItemGroupId", DbType.Int32, model.ItemGroupId);
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "Subject", DbType.AnsiString, model.Subject);
			db.AddInParameter(dbCommand, "Content", DbType.AnsiString, model.Content);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ItemGroupId)
		{
            Database db = DBFactory.DbWriter;
			DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItemGroup_Delete");
			db.AddInParameter(dbCommand, "ItemGroupId", DbType.Int32,ItemGroupId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteItemGroup GetModel(int ItemGroupId)
		{
            Database db = DBFactory.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItemGroup_GetModel");
			db.AddInParameter(dbCommand, "ItemGroupId", DbType.Int32,ItemGroupId);

			NoName.NetShop.Vote.Model.VoteItemGroup model=null;
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
		public List<NoName.NetShop.Vote.Model.VoteItemGroup> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ItemGroupId,VoteId,Subject,Content ");
			strSql.Append(" FROM voVoteItemGroup ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Vote.Model.VoteItemGroup> list = new List<NoName.NetShop.Vote.Model.VoteItemGroup>();
            Database db = DBFactory.DbReader;
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
		public NoName.NetShop.Vote.Model.VoteItemGroup ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Vote.Model.VoteItemGroup model=new NoName.NetShop.Vote.Model.VoteItemGroup();
			object ojb; 
			ojb = dataReader["ItemGroupId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ItemGroupId=(int)ojb;
			}
			ojb = dataReader["VoteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteId=(int)ojb;
			}
			model.Subject=dataReader["Subject"].ToString();
			model.Content=dataReader["Content"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

