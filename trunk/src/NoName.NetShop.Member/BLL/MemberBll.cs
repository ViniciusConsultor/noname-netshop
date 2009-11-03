using System;
using System.Data;
using System.Collections.Generic;

using NoName.NetShop.Member.Model;
namespace NoName.NetShop.Member.BLL
{
	/// <summary>
	/// ҵ���߼���Member ��ժҪ˵����
	/// </summary>
	public class Member
	{
		private readonly NoName.NetShop.Member.DAL.Member dal=new NoName.NetShop.Member.DAL.Member();
		public Member()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(NoName.NetShop.Member.Model.MemberModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(NoName.NetShop.Member.Model.MemberModel model)
		{
			dal.Update(model);
		}

        public void SetStatus(int userId, MemberStatus status)
        {
            dal.SetStatus(userId, status);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int userId)
		{
			dal.Delete(userId);
		}

        public bool Exists(string userEmail)
        {
            return dal.Exists(userEmail);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public NoName.NetShop.Member.Model.MemberModel GetModel(int userId)
		{
			
			return dal.GetModel(userId);
		}

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public NoName.NetShop.Member.Model.MemberModel GetModel(string userEmail)
        {
            return dal.GetModel(userEmail);
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
		public List<NoName.NetShop.Member.Model.MemberModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<NoName.NetShop.Member.Model.MemberModel> DataTableToList(DataTable dt)
		{
			List<NoName.NetShop.Member.Model.MemberModel> modelList = new List<NoName.NetShop.Member.Model.MemberModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NoName.NetShop.Member.Model.MemberModel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NoName.NetShop.Member.Model.MemberModel();
					if(dt.Rows[n]["userId"].ToString()!="")
					{
						model.userId=int.Parse(dt.Rows[n]["userId"].ToString());
					}
					model.UserEmail=dt.Rows[n]["UserEmail"].ToString();
					model.Password=dt.Rows[n]["Password"].ToString();
					model.NickName=dt.Rows[n]["NickName"].ToString();
					if(dt.Rows[n]["AllScore"].ToString()!="")
					{
						model.AllScore=int.Parse(dt.Rows[n]["AllScore"].ToString());
					}
					if(dt.Rows[n]["CurScore"].ToString()!="")
					{
						model.CurScore=int.Parse(dt.Rows[n]["CurScore"].ToString());
					}
					if(dt.Rows[n]["LastLogin"].ToString()!="")
					{
						model.LastLogin=DateTime.Parse(dt.Rows[n]["LastLogin"].ToString());
					}
					model.LoginIP=dt.Rows[n]["LoginIP"].ToString();
					if(dt.Rows[n]["RegisterTime"].ToString()!="")
					{
						model.RegisterTime=DateTime.Parse(dt.Rows[n]["RegisterTime"].ToString());
					}
					if(dt.Rows[n]["UserType"].ToString()!="")
					{
						model.UserType=(MemberType)int.Parse(dt.Rows[n]["UserType"].ToString());
					}
					if(dt.Rows[n]["status"].ToString()!="")
					{
						model.Status=(MemberStatus)int.Parse(dt.Rows[n]["status"].ToString());
					}
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

		#endregion  ��Ա����



        public bool ValidateUser(string username, string md5pass)
        {
            return dal.Validate(username, md5pass);
        }

        public bool ChangePassword(string userEmail, string oldpass, string newpass)
        {
            return dal.ChangePassword(userEmail, oldpass, newpass);
        }
    }
}

