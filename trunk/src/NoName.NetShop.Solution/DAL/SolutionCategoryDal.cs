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
	/// 数据访问类Category。
	/// </summary>
	public class SolutionCategoryDal
    {
        private Database dbw = CommDataAccess.DbWriter;
        private Database dbr = CommDataAccess.DbReader;

		public SolutionCategoryDal()
		{}
		#region  成员方法

		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Save(SolutionCategoryModel model)
		{			
			DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slCategory_Save");
            dbw.AddInParameter(dbCommand, "SenceId", DbType.Int32, model.SenceId);
            dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, model.CateId);
            dbw.AddInParameter(dbCommand, "CateImage", DbType.AnsiString, model.CateImage);
            dbw.AddInParameter(dbCommand, "Remark", DbType.AnsiString, model.Remark);
            dbw.AddInParameter(dbCommand, "Position", DbType.AnsiString, model.Position);
            dbw.AddInParameter(dbCommand, "IsShow", DbType.Boolean, model.IsShow);
            dbw.ExecuteNonQuery(dbCommand);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SenceId,int CateId)
		{
            DbCommand dbCommand = dbw.GetStoredProcCommand("UP_slCategory_Delete");
            dbw.AddInParameter(dbCommand, "SenceId", DbType.Int32, SenceId);
            dbw.AddInParameter(dbCommand, "CateId", DbType.Int32, CateId);

            dbw.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SolutionCategoryModel GetModel(int SenceId,int CateId)
		{
			
			DbCommand dbCommand = dbr.GetStoredProcCommand("UP_slCategory_GetModel");
            dbr.AddInParameter(dbCommand, "SenceId", DbType.Int32, SenceId);
            dbr.AddInParameter(dbCommand, "CateId", DbType.Int32, CateId);

			SolutionCategoryModel model=null;
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
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<SolutionCategoryModel> GetModelList(string where)
        {
            string sql = "SELECT * FROM [slCategory]  where " + where;
            List<SolutionCategoryModel> list = new List<SolutionCategoryModel>();

            using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;

        }

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
        public List<SolutionCategoryModel> GetListArray(int scenceId)
		{
            string sql = "SELECT a.SenceId,a.CateId,a.CateImage,a.Remark,a.Position,a.IsShow,b.catename FROM [slCategory] as a"
                + "	join dbo.pdCategory as b on a.cateid=b.cateId where a.senceId= " + scenceId;
            List<SolutionCategoryModel> list = new List<SolutionCategoryModel>();

            using (IDataReader dataReader = dbr.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list; 
            
		}




		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public SolutionCategoryModel ReaderBind(IDataReader dataReader)
		{
			SolutionCategoryModel model=new SolutionCategoryModel();
			object ojb; 
			ojb = dataReader["SenceId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SenceId=(int)ojb;
			}
			ojb = dataReader["CateId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CateId=(int)ojb;
			}
			model.CateImage=dataReader["CateImage"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			model.Position=dataReader["Position"].ToString();
            model.CateName = dataReader["catename"].ToString();
			ojb = dataReader["IsShow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsShow=(bool)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

