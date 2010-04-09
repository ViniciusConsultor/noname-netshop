using System;
using System.Data;
using System.Collections.Generic;
namespace NoName.NetShop.ShopFlow
{
    /// <summary>
    /// 业务逻辑类unExpressInfo 的摘要说明。
    /// </summary>
    public class ExpressInfoBll
    {
        private readonly NoName.NetShop.ShopFlow.ExpressInfoDal dal = new ExpressInfoDal();
        public ExpressInfoBll()
        { }
        #region  成员方法
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(NoName.NetShop.ShopFlow.ExpressInfoModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NoName.NetShop.ShopFlow.ExpressInfoModel GetModel(int RuleId)
        {

            return dal.GetModel(RuleId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NoName.NetShop.ShopFlow.ExpressInfoModel> GetModelList(string strWhere)
        {
            return dal.GetListArray(strWhere);
        }

        #endregion  成员方法
    }
}

