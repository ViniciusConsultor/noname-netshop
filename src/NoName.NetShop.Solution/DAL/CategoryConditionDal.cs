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
	/// 数据访问类CategoryCondition。
	/// </summary>
	public class CategoryConditionDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

        public CategoryConditionDal()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
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
		/// 获得数据列表（比DataSet效率高，推荐使用）
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

        public DataTable GetCategoryProductList(bool IsJoinProperity,string ConditionString)//int CurrentCategoryID,int ScenceID)
        {
            string sql = String.Empty;
            if (IsJoinProperity)
            {
                sql = @"select * from pdProduct
                            inner join pdProductPara on pdProductPara.productid=pdProduct.productid
                        where 1=1 and " + ConditionString.Substring(0, ConditionString.LastIndexOf("and"));
            }
            else
            {
                sql = @"select * from pdProduct where 1=1 and " + ConditionString.Substring(0, ConditionString.LastIndexOf("and")); 
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


		/// <summary>
		/// 对象实体绑定数据
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

		#endregion  成员方法
	}
}

