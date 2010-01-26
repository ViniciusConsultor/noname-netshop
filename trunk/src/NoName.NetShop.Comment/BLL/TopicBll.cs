using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;
using System.Data;

namespace NoName.NetShop.Comment
{
    public class TopicBll
    {
        private readonly NoName.NetShop.Comment.TopicDal dal = new NoName.NetShop.Comment.TopicDal();
        public TopicBll()
		{}
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Comment.TopicModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int topicId)
		{

            dal.Delete(topicId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public NoName.NetShop.Comment.TopicModel GetModel(int topicId)
		{

            return dal.GetModel(topicId);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<NoName.NetShop.Comment.TopicModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(0,strWhere);
		}

        public List<NoName.NetShop.Comment.TopicModel> GetModelList(int top, string strWhere)
        {
            return dal.GetListArray(top,strWhere);
        }

        public List<NoName.NetShop.Comment.TopicModel> GetModelList(int contentId, ContentType contentType)
        {
            string strWhere = "conentId=" + contentId + " and contentType " + (int)contentType;
            return dal.GetListArray(0, strWhere);
        }
        public List<NoName.NetShop.Comment.TopicModel> GetModelList(int contentId, ContentType contentType, int top)
        {
            string strWhere = "conentId=" + contentId + " and contentType " + (int)contentType;
            return dal.GetListArray(top, strWhere);
        }

        public DataTable GetList(int PageIndex, int PageSize, int TargetID, ContentType contentType, out int RecordCount)
        {
            return dal.GetList(PageIndex, PageSize, TargetID, contentType, out RecordCount);
        }
		#endregion  成员方法

        public void ToggleStatus(int topicId)
        {
            dal.ToggleStatus(topicId);
        }
    }
}
