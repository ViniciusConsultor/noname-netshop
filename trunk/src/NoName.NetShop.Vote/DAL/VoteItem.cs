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
	/// ���ݷ�����VoteItems��
	/// </summary>
	public class VoteItem
	{
		public VoteItem()
		{}
		#region  ��Ա����


		/// <summary>
		///  ����һ������
		/// </summary>
		public void Save(NoName.NetShop.Vote.Model.VoteItem model)
		{
            if (model.ItemId == 0)
            {
                model.ItemId = NoName.NetShop.Common.CommDataHelper.GetNewSerialNum(AppType.Other);
            }
            Database db = DBFactory.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItem_Save");
			db.AddInParameter(dbCommand, "ItemGroupId", DbType.Int32, model.ItemGroupId);
			db.AddInParameter(dbCommand, "VoteId", DbType.Int32, model.VoteId);
			db.AddInParameter(dbCommand, "ItemId", DbType.Int32, model.ItemId);
			db.AddInParameter(dbCommand, "ItemContent", DbType.AnsiString, model.ItemContent);
			db.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ItemId)
		{
            Database db = DBFactory.DbWriter;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItem_Delete");
			db.AddInParameter(dbCommand, "ItemId", DbType.Int32,ItemId);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Vote.Model.VoteItem GetModel(int ItemId)
		{
            Database db = DBFactory.DbReader;
            DbCommand dbCommand = db.GetStoredProcCommand("UP_voVoteItem_GetModel");
			db.AddInParameter(dbCommand, "ItemId", DbType.Int32,ItemId);

			NoName.NetShop.Vote.Model.VoteItem model=null;
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
		public List<NoName.NetShop.Vote.Model.VoteItem> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ItemGroupId,VoteId,ItemId,ItemContent,VoteCount ");
			strSql.Append(" FROM voVoteItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<NoName.NetShop.Vote.Model.VoteItem> list = new List<NoName.NetShop.Vote.Model.VoteItem>();
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
		public NoName.NetShop.Vote.Model.VoteItem ReaderBind(IDataReader dataReader)
		{
			NoName.NetShop.Vote.Model.VoteItem model=new NoName.NetShop.Vote.Model.VoteItem();
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
			ojb = dataReader["ItemId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ItemId=(int)ojb;
			}
			model.ItemContent=dataReader["ItemContent"].ToString();
			ojb = dataReader["VoteCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteCount=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

