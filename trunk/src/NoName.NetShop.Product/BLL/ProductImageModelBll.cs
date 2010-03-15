using System;
using System.Data;
using System.Collections.Generic;
using NoName.NetShop.Product.DAL;
using NoName.NetShop.Product.Model;

namespace NoName.NetShop.Product.BLL
{
	/// <summary>
	/// ҵ���߼���ProductImageModelBll ��ժҪ˵����
	/// </summary>
	public class ProductImageModelBll
	{
		private readonly ProductImageModelDal dal=new ProductImageModelDal();
		public ProductImageModelBll()
		{}
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
		public bool Exists(int ImageId)
		{
			return dal.Exists(ImageId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ProductImageModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ProductImageModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ImageId)
		{
			
			dal.Delete(ImageId);
		}

        public void SwitchOrder(int OrginalID, int SwitchedID)
        {
            dal.SwitchOrder(OrginalID, SwitchedID);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ProductImageModel GetModel(int ImageId)
		{
			
			return dal.GetModel(ImageId);
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
		public List<ProductImageModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ProductImageModel> modelList = new List<ProductImageModel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ProductImageModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ProductImageModel();
					if(ds.Tables[0].Rows[n]["ImageId"].ToString()!="")
					{
						model.ImageId=int.Parse(ds.Tables[0].Rows[n]["ImageId"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ProductId"].ToString()!="")
					{
						model.ProductId=int.Parse(ds.Tables[0].Rows[n]["ProductId"].ToString());
					}
					model.SmallImage=ds.Tables[0].Rows[n]["SmallImage"].ToString();
					model.LargeImage=ds.Tables[0].Rows[n]["LargeImage"].ToString();
					model.OriginImage=ds.Tables[0].Rows[n]["OriginImage"].ToString();
					model.Title=ds.Tables[0].Rows[n]["Title"].ToString();
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


        public DataSet GetList(int ProductID)
        {
            return dal.GetList(" productid = "+ProductID);
        }


		#endregion  ��Ա����
	}
}

