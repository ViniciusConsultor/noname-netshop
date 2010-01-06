using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Comment
{
    public class AnswerBll
    {
        private readonly NoName.NetShop.Comment.AnswerDal dal=new NoName.NetShop.Comment.AnswerDal();
        public AnswerBll()
		{}
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Save(NoName.NetShop.Comment.AnswerModel model)
		{
			dal.Save(model);
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
        public NoName.NetShop.Comment.AnswerModel GetModel(int AnswerId)
		{
			
			return dal.GetModel(AnswerId);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<NoName.NetShop.Comment.AnswerModel> GetModelOfQuestion(int questionId)
		{
            return dal.GetListArray(questionId);
		}


		#endregion  成员方法
    }
}
