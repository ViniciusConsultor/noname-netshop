using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Comment
{
    public class ReplyBll
    {
        private readonly NoName.NetShop.Comment.ReplyDal dal = new NoName.NetShop.Comment.ReplyDal();
        public ReplyBll()
		{}
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(NoName.NetShop.Comment.ReplyModel model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AnswerId)
		{
			dal.Delete(AnswerId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public NoName.NetShop.Comment.ReplyModel GetModel(int AnswerId)
		{
			
			return dal.GetModel(AnswerId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<NoName.NetShop.Comment.ReplyModel> GetModelOfTopic(int questionId)
		{
            return dal.GetListArray(questionId);
		}


		#endregion  成员方法
    }
}
