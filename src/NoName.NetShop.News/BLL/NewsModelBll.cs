using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.News.DAL;
using NoName.NetShop.News.Model;
using NoName.NetShop.Common;
namespace NoName.NetShop.News.BLL
{
	/// <summary>
	/// ҵ���߼���NewsModelBll ��ժҪ˵����
	/// </summary>
	public class NewsModelBll
	{
		private readonly NewsModelDal dal=new NewsModelDal();

        public NewsModelBll()
        { }
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int NewsId)
		{
			return dal.Exists(NewsId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NewsModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NewsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int NewsId)
		{
			
			dal.Delete(NewsId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NewsModel GetModel(int NewsId)
		{
			
			return dal.GetModel(NewsId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NewsModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<NewsModel> modelList = new List<NewsModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				NewsModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NewsModel();
					if(ds.Tables[0].Rows[n]["NewsId"].ToString()!="")
					{
						model.NewsId=int.Parse(ds.Tables[0].Rows[n]["NewsId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["NewsType"].ToString()!="")
					{
						model.NewsType=int.Parse(ds.Tables[0].Rows[n]["NewsType"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
					}
					model.Title=ds.Tables[0].Rows[n]["Title"].ToString();
					model.SubTitle=ds.Tables[0].Rows[n]["SubTitle"].ToString();
					model.Brief=ds.Tables[0].Rows[n]["Brief"].ToString();
					model.Content=ds.Tables[0].Rows[n]["Content"].ToString();
					model.SmallImageUrl=ds.Tables[0].Rows[n]["SmallImageUrl"].ToString();
					model.Author=ds.Tables[0].Rows[n]["Author"].ToString();
					model.From=ds.Tables[0].Rows[n]["From"].ToString();
					model.VideoUrl=ds.Tables[0].Rows[n]["VideoUrl"].ToString();
					model.ImageUrl=ds.Tables[0].Rows[n]["ImageUrl"].ToString();
					model.ProductId=ds.Tables[0].Rows[n]["ProductId"].ToString();
					if(ds.Tables[0].Rows[n]["InsertTime"].ToString()!="")
					{
						model.InsertTime=DateTime.Parse(ds.Tables[0].Rows[n]["InsertTime"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ModifyTime"].ToString()!="")
					{
						model.ModifyTime=DateTime.Parse(ds.Tables[0].Rows[n]["ModifyTime"].ToString());
					}
					model.Tags=ds.Tables[0].Rows[n]["Tags"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }


        public DataTable GetList(int PageIndex, int PageSize, string Condition, out int RecordCount)
        {
            SearchPageInfo info = new SearchPageInfo();

            info.FieldNames = "*";
            info.OrderType = "";
            info.PageIndex = PageIndex;
            info.PageSize = PageSize;
            info.PriKeyName = "newsid";
            info.StrJoin = "";
            info.StrWhere = " 1=1 " + Condition;
            info.TableName = "nenews";
            info.TotalFieldStr = "";

            DataTable dt = CommDataHelper.GetDataFromSingleTableByPage(info).Tables[0];

            RecordCount = info.TotalItem;

            return dt;
        }


		#endregion  ��Ա����
	}
}

