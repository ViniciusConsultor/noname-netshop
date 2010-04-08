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
	/// ���ݷ�����CategoryModelDal��
	/// </summary>
	public class CategoryModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public CategoryModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CateId)+1 from pdCategory";
			
			object obj = dbr.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int CateId)
		{
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdCategory_Exists");
			dbr.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);
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
		public void Add(CategoryModel model)
		{
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdCategory_ADD");
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			dbw.AddInParameter(dbCommand, "CateName", DbType.AnsiString, model.CateName);
			dbw.AddInParameter(dbCommand, "Status", DbType.Int32, model.Status);
            dbw.AddInParameter(dbCommand, "IsHide", DbType.Boolean, model.IsHide);
            dbw.AddInParameter(dbCommand, "CateLevel", DbType.Int32, model.CateLevel);
            dbw.AddInParameter(dbCommand, "Parentid", DbType.Int32, model.ParentID);
			dbw.AddInParameter(dbCommand, "PriceRange", DbType.AnsiString, model.PriceRange);
            dbw.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
            dbw.AddInParameter(dbCommand, "showorder", DbType.Int32, model.ShowOrder);
            dbw.AddInParameter(dbCommand, "pinyinname", DbType.String, model.PinYinName);


			dbw.ExecuteNonQuery(dbCommand);
		} 
		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(CategoryModel model)
		{
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdCategory_Update");
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
			dbw.AddInParameter(dbCommand, "CateName", DbType.AnsiString, model.CateName);
			dbw.AddInParameter(dbCommand, "CatePath", DbType.AnsiString, model.CatePath);
			dbw.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			dbw.AddInParameter(dbCommand, "PriceRange", DbType.AnsiString, model.PriceRange);
			dbw.AddInParameter(dbCommand, "IsHide", DbType.Boolean, model.IsHide);
            dbw.AddInParameter(dbCommand, "CateLevel", DbType.Byte, model.CateLevel);
            dbw.AddInParameter(dbCommand, "showorder", DbType.Int32, model.ShowOrder);
            dbw.AddInParameter(dbCommand, "pinyinname", DbType.String, model.PinYinName);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CateId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdCategory_Delete");
			dbw.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);

			dbw.ExecuteNonQuery(dbCommand);
		}

        public void DeleteOffsprings(int AncestorID)
        {
            string sql = "delete from pdcategory where catepath like (select catepath+'%' from pdcategory where cateid=" + AncestorID + ")";
            dbw.ExecuteNonQuery(CommandType.Text, sql);
        }

        public DataTable GetOffsprings(int AncestorID)
        {
            string sql = "select * from pdcategory where catepath like (select catepath+'%' from pdcategory where cateid=" + AncestorID + ")";
            return dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public CategoryModel GetModel(int CateId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdCategory_GetModel");
			dbr.AddInParameter(dbCommand, "CateId", DbType.Int32,CateId);

			CategoryModel model=null;
			using (IDataReader dataReader = dbr.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

        public string GetCategoryPath(int CategoryID)
        {
            string sql = "select catepath from pdcategory where cateid={0}";
            sql = String.Format(sql, CategoryID);
            return dbr.ExecuteScalar(CommandType.Text, sql).ToString();
        }

        public string GetCategoryNamePath(int CategoryID)
        {
            string sql = "select dbo.[GetProductCategoryNamePath]({0}) as catepath";
            sql = String.Format(sql,CategoryID);
            return dbr.ExecuteScalar(CommandType.Text, sql).ToString();
        }

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM pdCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			
			return dbr.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_GetRecordByPage");
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdCategory");
			dbr.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			dbr.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			dbr.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			dbr.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return dbr.ExecuteDataSet(dbCommand);
		}


        public bool HasChild(int CategoryID)
        {
            string sql = "select count(0) from pdcategory where parentid = " + CategoryID;
            return Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, sql)) > 0;
        }

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<CategoryModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM pdCategory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<CategoryModel> list = new List<CategoryModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}

        public int SwitchOrder(int InitialCategoryID, int ReplacedCategoryID)
        {
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdCategory_ChangeOrder");

            dbr.AddInParameter(dbCommand, "@initialcateid", DbType.Int32, InitialCategoryID);
            dbr.AddInParameter(dbCommand, "@replacedcateid", DbType.Int32, ReplacedCategoryID);

            return dbr.ExecuteNonQuery(dbCommand); 
        }

        public int GetChildCount(int ParentID)
        {
            string sql = String.Format("select count(0) from pdcategory where parentid = {0}",ParentID);
            return Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text,sql));
        }

        public string GetCategoryName(int CategoryID)
        {
            string sql = "select catename from pdcategory where cateid=" + CategoryID;
            return dbr.ExecuteScalar(CommandType.Text, sql).ToString();
        }


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public CategoryModel ReaderBind(IDataReader dataReader)
		{
            CategoryModel model = new CategoryModel() ;
			object ojb; 
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
            }
            ojb = dataReader["CateLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CateLevel = int.Parse(ojb.ToString());
            }
			model.CateName=dataReader["CateName"].ToString();
			model.CatePath=dataReader["CatePath"].ToString();
            ojb = dataReader["IsHide"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsHide = (bool)ojb;
            }
            ojb = dataReader["parentid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentID = int.Parse(ojb.ToString());
            }
            model.PriceRange = dataReader["PriceRange"].ToString();
            model.Remark = dataReader["remark"].ToString();
            ojb = dataReader["showorder"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ShowOrder = int.Parse(ojb.ToString());
            }
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=int.Parse(ojb.ToString());
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

