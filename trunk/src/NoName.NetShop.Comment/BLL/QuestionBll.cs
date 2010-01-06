using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoName.NetShop.Common;

namespace NoName.NetShop.Comment
{
    public class QuestionBll
    {
        private readonly NoName.NetShop.Comment.QuestionDal dal=new NoName.NetShop.Comment.QuestionDal();
        public QuestionBll()
		{}
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Comment.QuestionModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int QuestionId)
		{
			
			dal.Delete(QuestionId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public NoName.NetShop.Comment.QuestionModel GetModel(int QuestionId)
		{
			
			return dal.GetModel(QuestionId);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<NoName.NetShop.Comment.QuestionModel> GetModelList(string strWhere)
		{
            return dal.GetListArray(0,strWhere);
		}

        public List<NoName.NetShop.Comment.QuestionModel> GetModelList(int top, string strWhere)
        {
            return dal.GetListArray(top,strWhere);
        }

        public List<NoName.NetShop.Comment.QuestionModel> GetModelList(int contentId, ContentType contentType)
        {
            string strWhere = "conentId=" + contentId + " and contentType " + (int)contentType;
            return dal.GetListArray(0, strWhere);
        }
        public List<NoName.NetShop.Comment.QuestionModel> GetModelList(int contentId, ContentType contentType, int top)
        {
            string strWhere = "conentId=" + contentId + " and contentType " + (int)contentType;
            return dal.GetListArray(top, strWhere);
        }
		#endregion  成员方法
    }
}
