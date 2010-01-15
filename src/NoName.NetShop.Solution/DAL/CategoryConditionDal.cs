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
	/// ���ݷ�����CategoryCondition��
	/// </summary>
	public class CategoryConditionDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public CategoryConditionDal()
		{}
		#region  ��Ա����


		/// <summary>
		///  ����һ������
		/// </summary>
		public void Save(CategoryConditionModel model)
		{			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slCategoryCondition_Save");
            dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
            dbw.AddInParameter(dbCommand, "SenceId", DbType.Int32, model.SenceId);
            dbw.AddInParameter(dbCommand, "RuleName", DbType.AnsiString, model.RuleName);
            dbw.AddInParameter(dbCommand, "RuleValue", DbType.AnsiString, model.RuleValue);
            dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ��������б�����DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
        public List<CategoryConditionModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CateId,SenceId,RuleName,RuleValue ");
			strSql.Append(" FROM slCategoryCondition ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            List<CategoryConditionModel> list = new List<CategoryConditionModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}

        public DataTable GetCategoryProductList(int PageIndex,int PageSize,int CurrentCategoryID,out int RecordCount)
        {
            string Condition = GetModel(1, CurrentCategoryID).RuleValue;

            return GetCategoryProductList(PageIndex, PageSize, Condition, " productid desc ", out RecordCount);
        }

        public DataTable GetCategoryProductList(int PageIndex, int PageSize, string Condition, string Order, out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = "select count(0) from pdproduct where "+Condition;
            string sqlData = @" select * from
                                    (select row_number() over(order by "+Order+@") as nid,* 
                                    from pdproduct 
                                    where "+Condition+@") as sp
                                where nid>"+PageLowerBound+" and nid<="+PageUpperBount;

            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, sqlCount));
            return dbr.ExecuteDataSet(CommandType.Text, sqlData).Tables[0];
        }

        public CategoryConditionModel GetModel(int ScenceID,int CategoryID)
        {
            string sql = "select * from slcategorycondition where senceid={0} and cateid={1}";


            CategoryConditionModel model = null;
            using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, String.Format(sql, ScenceID, CategoryID)))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


		/// <summary>
		/// ����ʵ�������
		/// </summary>
        public CategoryConditionModel ReaderBind(IDataReader dataReader)
		{
            CategoryConditionModel model = new CategoryConditionModel();
			object ojb; 
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			ojb = dataReader["SenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SenceId=Convert.ToInt32(ojb);
			}
			model.RuleName=dataReader["RuleName"].ToString();
			model.RuleValue=dataReader["RuleValue"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}
