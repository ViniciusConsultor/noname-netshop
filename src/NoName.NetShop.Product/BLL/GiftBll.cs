using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoName.NetShop.Product.BLL
{
    /// <summary>
    /// 业务逻辑类pdGift 的摘要说明。
    /// </summary>
    public class GiftBll
    {
        private readonly NoName.NetShop.Product.DAL.GiftDal dal = new NoName.NetShop.Product.DAL.GiftDal();
        public GiftBll()
        { }
        #region  成员方法

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Save(NoName.NetShop.Product.Model.GiftModel model)
        {
            dal.Save(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ProductId)
        {

            dal.Delete(ProductId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NoName.NetShop.Product.Model.GiftModel GetModel(int ProductId)
        {
            return dal.GetModel(ProductId);
        }

        #endregion  成员方法
    }

}
