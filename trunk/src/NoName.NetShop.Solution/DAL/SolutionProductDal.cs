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
	/// ���ݷ�����Product��
	/// </summary>
	public class SolutionProductDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public SolutionProductDal()
		{}
		#region  ��Ա����


		/// <summary>
		///  ����һ������
		/// </summary>
		public void Save(SolutionProductModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slProduct_Save");
			dbw.AddInParameter(dbCommand, "SuiteId", DbType.Int32, model.SuiteId);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "Price", DbType.Decimal, model.Price);
			dbw.AddInParameter(dbCommand, "Quantity", DbType.Int32, model.Quantity);
			dbw.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SuiteId,int ProductId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slProduct_Delete");
			dbw.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);

			dbw.ExecuteNonQuery(dbCommand);
		}



		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<SolutionProductModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select sp.SuiteId,sp.ProductId,sp.Price,sp.Quantity,p.productname from slproduct sp inner join pdproduct p on sp.productid=p.productid");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}

 			List<SolutionProductModel> list = new List<SolutionProductModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}

        public DataTable GetList(int SuiteID)
        {
            string sql = @" select * from slproduct sp
                                inner join pdproduct p on sp.productid=p.productid
                            where sp.suiteid="+SuiteID;
            return dbr.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        }


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public SolutionProductModel ReaderBind(IDataReader dataReader)
		{
			SolutionProductModel model=new SolutionProductModel();
			object ojb; 
			ojb = dataReader["SuiteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SuiteId=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=(decimal)ojb;
			}
			ojb = dataReader["Quantity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Quantity=(int)ojb;
			}
            model.ProductName = dataReader["ProductName"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

