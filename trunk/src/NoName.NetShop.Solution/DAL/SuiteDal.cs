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
	/// 数据访问类Suite。
	/// </summary>
	public class SuiteDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public SuiteDal()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SuiteId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_slSuite_Exists");
			dbr.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);
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
		///  增加一条数据
		/// </summary>
		public void Save(SuiteModel model)
		{
            if (model.SuiteId == 0)
                model.SuiteId = CommDataHelper.GetNewSerialNum(AppType.Product); // 因为图片部分与商品类似，因此这里的id也采用了商品一致的id序列
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slSuite_Save");
			dbw.AddInParameter(dbCommand, "SuiteId", DbType.Int32, model.SuiteId);
			dbw.AddInParameter(dbCommand, "ScenceId", DbType.Int32, model.ScenceId);
			dbw.AddInParameter(dbCommand, "SuiteName", DbType.AnsiString, model.SuiteName);
            dbw.AddInParameter(dbCommand, "LargeImage", DbType.AnsiString, model.LargeImage);
            dbw.AddInParameter(dbCommand, "SmallImage", DbType.AnsiString, model.SmallImage);
			dbw.AddInParameter(dbCommand, "MediumImage", DbType.AnsiString, model.MediumImage);
			dbw.AddInParameter(dbCommand, "Price", DbType.Decimal, model.Price);
			dbw.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
			dbw.AddInParameter(dbCommand, "Score", DbType.Int32, model.Score);
			dbw.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SuiteId)
		{
			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slSuite_Delete");
			dbw.AddInParameter(dbCommand, "SuiteId", DbType.Int32,SuiteId);

			dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SuiteModel GetModel(int SuiteId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_slSuite_GetModel");
            dbr.AddInParameter(dbCommand, "SuiteId", DbType.Int32, SuiteId);

			SuiteModel model=null;
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
        /// 根据商品单件计算套装总价
        /// </summary>
        /// <param name="suiteId"></param>
        public void SetPriceFromRefrence(int suiteId)
        {
            DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slSuite_SetPriceFromReference");
            dbw.AddInParameter(dbCommand, "SuiteId", DbType.Int32, suiteId);
            dbw.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<SuiteModel> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select SuiteId,ScenceId,SuiteName,LargeImage,SmallImage,MediumImage,Price,Remark,Score ");
			strSql.Append(" FROM slSuite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<SuiteModel> list = new List<SuiteModel>();

            using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


        public DataTable GetList(int PageIndex, int PageSize, string Condition, string Order, out int RecordCount)
        {
            int PageLowerBound = 0, PageUpperBount = 0;
            PageLowerBound = (PageIndex - 1) * PageSize;
            PageUpperBount = PageLowerBound + PageSize;

            string sqlCount = @"select count(0) from [slsuite] where 1=1 " + Condition;
            string sqlData = @" select * from
                                (select row_number() over (order by " + (String.IsNullOrEmpty(Order) ? "suiteid desc" : Order) + @") as id,* from [slsuite])
                                as sp
                                where id > " + PageLowerBound + " and id<" + PageUpperBount + " " + Condition;

            RecordCount = Convert.ToInt32(dbr.ExecuteScalar(CommandType.Text, sqlCount));

            return dbr.ExecuteDataSet(CommandType.Text, sqlData).Tables[0];
        }

		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public SuiteModel ReaderBind(IDataReader dataReader)
		{
			SuiteModel model=new SuiteModel();
			object ojb; 
			ojb = dataReader["SuiteId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SuiteId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["ScenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ScenceId=Convert.ToInt32(ojb);
			}
			model.SuiteName=dataReader["SuiteName"].ToString();
			model.SmallImage=dataReader["SmallImage"].ToString();
			model.MediumImage=dataReader["MediumImage"].ToString();
            model.LargeImage = dataReader["LargeImage"].ToString();
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=Convert.ToDecimal(ojb);
			}
			model.Remark=dataReader["Remark"].ToString();
			ojb = dataReader["Score"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Score=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  成员方法
	}
}

