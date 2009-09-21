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
	/// ���ݷ�����ProductParaModelDal��
	/// </summary>
	public class ProductParaModelDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public ProductParaModelDal()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ProductId)+1 from pdProductPara";
			
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
		public bool Exists(int ProductId,int ParaId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdProductPara_Exists");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbr.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);
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
		public void Add(ProductParaModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductPara_ADD");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "ParaId", DbType.Int32, model.ParaId);
			dbw.AddInParameter(dbCommand, "ParaValue", DbType.AnsiString, model.ParaValue);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(ProductParaModel model)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductPara_Update");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32, model.ProductId);
			dbw.AddInParameter(dbCommand, "ParaId", DbType.Int32, model.ParaId);
			dbw.AddInParameter(dbCommand, "ParaValue", DbType.AnsiString, model.ParaValue);
			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductId,int ParaId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_pdProductPara_Delete");
			dbw.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbw.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ProductParaModel GetModel(int ProductId,int ParaId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_pdProductPara_GetModel");
			dbr.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
			dbr.AddInParameter(dbCommand, "ParaId", DbType.Int32,ParaId);

			ProductParaModel model=null;
			using (IDataReader dataReader = dbr.ExecuteReader(dbCommand))
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
			strSql.Append("select ProductId,ParaId,ParaValue ");
			strSql.Append(" FROM pdProductPara ");
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
			dbr.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "pdProductPara");
			dbr.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			dbr.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			dbr.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			dbr.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			dbr.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return dbr.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<ProductParaModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductId,ParaId,ParaValue ");
			strSql.Append(" FROM pdProductPara ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<ProductParaModel> list = new List<ProductParaModel>();
			
			using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
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
		public ProductParaModel ReaderBind(IDataReader dataReader)
		{
			ProductParaModel model=new ProductParaModel();
			object ojb; 
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["ParaId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ParaId=(int)ojb;
			}
			model.ParaValue=dataReader["ParaValue"].ToString();
			return model;
		}

		#endregion  ��Ա����
	}
}

