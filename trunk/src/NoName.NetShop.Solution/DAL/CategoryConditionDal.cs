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
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
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

        public DataTable GetCategoryProductList(bool IsJoinProperity,string ConditionString,int OrderType)//int CurrentCategoryID,int ScenceID)
        {
            string sql = String.Empty;

            if (IsJoinProperity)
            {
                sql = @"select * from pdProduct
                            inner join pdProductPara on pdProductPara.productid=pdProduct.productid
                        where 1=1 and " + ConditionString + @" order by " + "pdproduct." + (OrderType == 2 ? "merchantprice asc" : " merchantprice desc");
            }
            else
            {
                sql = @"select * from pdProduct where 1=1 and " + ConditionString + " order by " + (OrderType == 2 ? "merchantprice asc" : " merchantprice desc");
            }

            return dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
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

        public DataTable GetConditionSubCategory(int ScenceID, int CategoryID)
        {
            string sql = "select * from slcategorycondition where senceid={0} and cateid={1}";
            sql = String.Format(sql, ScenceID, CategoryID);
            string SubCategoryCondition = String.Empty;

            DataTable dt = dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string RuleName = row["RuleName"].ToString();
                string RuleValue = row["RuleValue"].ToString();

                if (RuleName.Contains("cateid"))
                {
                    SubCategoryCondition = RuleValue;
                }
            }

            if (SubCategoryCondition == String.Empty)
            {
                return null;
            }
            else
            {
                string sql2 = "select * from pdcategory where cateid " + SubCategoryCondition;
                return dbr.ExecuteDataSet(CommandType.Text, sql2).Tables[0]; 
            }
        }

        public DataTable GetConditionBrandList(int ScenceID, int CategoryID)
        {
            string sql = "select * from slcategorycondition where senceid={0} and cateid={1}";
            sql = String.Format(sql, ScenceID, CategoryID);
            string BrandCondition = String.Empty;

            DataTable dt = dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string RuleName = row["RuleName"].ToString();
                string RuleValue = row["RuleValue"].ToString();

                if (RuleName.Contains("brandid"))
                {
                    BrandCondition = RuleValue;
                }
            }

            if (BrandCondition == String.Empty)
            {
                return null;
            }
            else
            {
                string sql2 = "select * from pdbrand where brandid " + BrandCondition;
                return dbr.ExecuteDataSet(CommandType.Text, sql2).Tables[0];
            }
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

